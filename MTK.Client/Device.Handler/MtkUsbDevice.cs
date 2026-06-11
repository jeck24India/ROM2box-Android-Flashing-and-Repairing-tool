using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using mtkclient.library;
using mtkclient.devicehandler;
using mtkclient.library.xflash;

namespace mtkclient.devicehandler
{
    internal class MtkUsbDevice : IMtkUsbDevice, IMtkDevice, IDisposable
    {
        private static int TIMEOUT;

        private Native.LibUsbContext m_context;

        private Native.LibUsbDevice? m_device;

        private Native.LibUsbDeviceDescriptor m_descriptor;

        private List<byte> m_claimedInterfaces;

        private Native.LibUsbDeviceHandle? m_handle;

        private Native.LibUsbEndpointDescriptor? m_readEp;

        private Native.LibUsbEndpointDescriptor? m_writeEp;

        public MtkUsbDevice(
            Native.LibUsbContext context,
            Native.LibUsbDevice device,
            Native.LibUsbDeviceDescriptor descriptor
        )
        {
            m_context = context;
            m_device = device;
            m_descriptor = descriptor;
            m_claimedInterfaces = new List<byte>();
        }

        private Native.LibUsbConfigDescriptor[] GetConfigurations()
        {
            if (m_device.HasValue)
            {
                Native.LibUsbConfigDescriptor[] array = new Native.LibUsbConfigDescriptor[
                    m_descriptor.NumConfigurations
                ];
                byte b = 0;
                while (b < m_descriptor.NumConfigurations)
                {
                    Native.Ptr<Native.LibUsbConfigDescriptor> config;
                    int num = Native.LibUsb1.libusb_get_config_descriptor(
                        m_device.Value,
                        b,
                        out config
                    );
                    if (num == 0)
                    {
                        array[b] = config.Get();
                        b = (byte)(b + 1);
                        continue;
                    }
                    throw new Exception("Unable to get device configuration descriptor: " + num);
                }
                return array;
            }
            throw new InvalidOperationException("Already disposed");
        }

        private Native.LibUsbInterfaceDescriptor[] GetInterfaces(
            Native.LibUsbConfigDescriptor configuration
        )
        {
            List<Native.LibUsbInterfaceDescriptor> list =
                new List<Native.LibUsbInterfaceDescriptor>();
            Native.LibUsbInterface[] array = configuration.Interface.Get(
                configuration.NumInterfaces
            );
            for (int i = 0; i < array.Length; i++)
            {
                Native.LibUsbInterface libUsbInterface = array[i];
                Native.Ptr<Native.LibUsbInterfaceDescriptor> altSetting =
                    libUsbInterface.AltSetting;
                Native.LibUsbInterfaceDescriptor[] collection = altSetting.Get(
                    libUsbInterface.NumAltSetting
                );
                list.AddRange(collection);
            }
            return list.ToArray();
        }

        private void Connect()
        {
            if (!m_device.HasValue)
            {
                throw new InvalidOperationException("Already disposed");
            }
            if (!m_handle.HasValue)
            {
                Native.LibUsbConfigDescriptor[] configurations = GetConfigurations();
                Native.LibUsbDeviceHandle handle;
                int num = Native.LibUsb1.libusb_open(m_device.Value, out handle);
                if (num == 0)
                {
                    Native.LibUsbInterfaceDescriptor libUsbInterfaceDescriptor = (
                        from x in GetInterfaces(configurations[0])
                        where x.InterfaceClass == 10
                        select x
                    ).FirstOrDefault();
                    if (libUsbInterfaceDescriptor.InterfaceClass == 0)
                    {
                        Native.LibUsb1.libusb_close(handle);
                        throw new Exception("DATA interface not found");
                    }
                    int num2 = Native.LibUsb1.libusb_claim_interface(handle, 0);
                    if (num2 == 0)
                    {
                        m_claimedInterfaces.Add(0);
                        if (libUsbInterfaceDescriptor.InterfaceNumber != 0)
                        {
                            num2 = Native.LibUsb1.libusb_claim_interface(
                                handle,
                                libUsbInterfaceDescriptor.InterfaceNumber
                            );
                            if (num2 != 0)
                            {
                                Native.LibUsb1.libusb_close(handle);
                                throw new Exception("Unable to claim DATA interface: " + num2);
                            }
                            m_claimedInterfaces.Add(libUsbInterfaceDescriptor.InterfaceNumber);
                        }
                        Native.LibUsbEndpointDescriptor[] source =
                            libUsbInterfaceDescriptor.Endpoint.Get(
                                libUsbInterfaceDescriptor.NumEndpoints
                            );
                        m_writeEp = (
                            from x in ((IEnumerable<Native.LibUsbEndpointDescriptor>)source).Select(
                                (Func<
                                    Native.LibUsbEndpointDescriptor,
                                    Native.LibUsbEndpointDescriptor?
                                >)((Native.LibUsbEndpointDescriptor x) => x)
                            )
                            where x.HasValue && (x.Value.EndpointAddress & 0x80) == 0
                            select x
                        ).FirstOrDefault();
                        if (m_writeEp.HasValue)
                        {
                            m_readEp = (
                                from x in (
                                    (IEnumerable<Native.LibUsbEndpointDescriptor>)source
                                ).Select(
                                    (Func<
                                        Native.LibUsbEndpointDescriptor,
                                        Native.LibUsbEndpointDescriptor?
                                    >)((Native.LibUsbEndpointDescriptor x) => x)
                                )
                                where x.HasValue && (x.Value.EndpointAddress & 0x80) == 128
                                select x
                            ).FirstOrDefault();
                            if (!m_readEp.HasValue)
                            {
                                Native.LibUsb1.libusb_close(handle);
                                throw new Exception("Read endpoint not found");
                            }
                            m_handle = handle;
                            return;
                        }
                        Native.LibUsb1.libusb_close(handle);
                        throw new Exception("Write endpoint not found");
                    }
                    Native.LibUsb1.libusb_close(handle);
                    throw new Exception("Unable to claim interface 0: " + num2);
                }
                throw new Exception("Unable to open libusb device: " + num);
            }
            throw new InvalidOperationException("Already connected");
        }

        public Task ConnectAsync()
        {
            return Task.Run((Action)Connect);
        }

        private int Read(byte[] buff, int offset, int len)
        {
            if (m_handle.HasValue && m_readEp.HasValue)
            {
                byte[] array = new byte[len];
                int transferred;
                int num = Native.LibUsb1.libusb_bulk_transfer(
                    m_handle.Value,
                    m_readEp.Value.EndpointAddress,
                    array,
                    len,
                    out transferred,
                    TIMEOUT
                );
                if (num == -7)
                {
                    throw new TimeoutException();
                }
                if (num < 0)
                {
                    throw new Exception("Error sending bulk transfer: " + num);
                }
                Array.Copy(array, 0, buff, offset, transferred);
                return transferred;
            }
            throw new InvalidOperationException("Not connected");
        }

        public Task<int> ReadAsync(
            byte[] buff,
            int offset,
            int len,
            CancellationToken cancellationToken
        )
        {
            byte[] buff2 = buff;
            return Task.Run(() => Read(buff2, offset, len));
        }

        private void Write(byte[] buff, int offset, int len)
        {
            if (m_handle.HasValue && m_writeEp.HasValue)
            {
                byte[] array = new byte[len];
                Array.Copy(buff, offset, array, 0, len);
                int transferred;
                int num = Native.LibUsb1.libusb_bulk_transfer(
                    m_handle.Value,
                    m_writeEp.Value.EndpointAddress,
                    array,
                    len,
                    out transferred,
                    TIMEOUT
                );
                if (num == -7)
                {
                    throw new TimeoutException();
                }
                if (num < 0)
                {
                    throw new Exception("Error sending bulk transfer: " + num);
                }
                return;
            }
            throw new InvalidOperationException("Not connected");
        }

        public Task WriteAsync(
            byte[] buff,
            int offset,
            int len,
            CancellationToken cancellationToken
        )
        {
            byte[] buff2 = buff;
            return Task.Run(
                delegate
                {
                    Write(buff2, offset, len);
                }
            );
        }

        private int SendControlMessage(
            byte requestType,
            byte request,
            ushort value,
            ushort index,
            byte[] data
        )
        {
            if (m_handle.HasValue)
            {
                int num = Native.LibUsb1.libusb_control_transfer(
                    m_handle.Value,
                    requestType,
                    request,
                    value,
                    index,
                    data,
                    (ushort)data.Length,
                    TIMEOUT
                );
                if (num == -7)
                {
                    throw new TimeoutException();
                }
                if (num < 0)
                {
                    throw new Exception("Error sending control transfer: " + num);
                }
                return num;
            }
            throw new InvalidOperationException("Not connected");
        }

        public Task<int> SendControlMessageAsync(
            byte requestType,
            byte request,
            ushort value,
            ushort index,
            byte[] data,
            CancellationToken cancellationToken
        )
        {
            byte[] data2 = data;
            return Task.Run(() => SendControlMessage(requestType, request, value, index, data2));
        }

        public Task ResetAsync()
        {
            if (!m_handle.HasValue)
            {
                throw new InvalidOperationException("Not connected");
            }
            ReleaseInterfaces();
            Native.LibUsb1.libusb_reset_device(m_handle.Value);
            return Task.CompletedTask;
        }

        private void ReleaseInterfaces()
        {
            if (!m_handle.HasValue)
            {
                throw new InvalidOperationException("Not connected");
            }
            foreach (byte claimedInterface in m_claimedInterfaces)
            {
                Native.LibUsb1.libusb_release_interface(m_handle.Value, claimedInterface);
            }
            m_readEp = null;
            m_writeEp = null;
            m_claimedInterfaces.Clear();
        }

        public void Dispose()
        {
            if (m_device.HasValue)
            {
                Native.LibUsb1.libusb_unref_device(m_device.Value);
                m_device = null;
            }
            if (m_handle.HasValue)
            {
                ReleaseInterfaces();
                Native.LibUsb1.libusb_close(m_handle.Value);
                m_handle = null;
            }
        }

        public override string ToString()
        {
            return $"LibUsb_{m_descriptor.IdVendor:X4}_{m_descriptor.IdProduct:X4}";
        }

        static MtkUsbDevice()
        {
            TIMEOUT = 120000;
        }
    }
}
