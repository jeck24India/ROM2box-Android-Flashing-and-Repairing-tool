using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using mtkclient.library;
using mtkclient.devicehandler;
using mtkclient.library.xflash;

namespace mtkclient.devicehandler
{
    internal class MtkUsbDeviceFinderService
    {
        private static Native.LibUsbContext? m_context;

        static MtkUsbDeviceFinderService()
        {
            if (Native.LibUsb1.libusb_init(out var context) != 0)
            {
                LogService.Information("Unable to init libusb");
                return;
            }
            int num = Native.LibUsb1.libusb_set_option(context, 1);
            if (num != 0)
            {
                LogService.Information("Unable to enable usbdk: {0}", num);
            }
            else
            {
                m_context = context;
            }
        }

        static Native.LibUsbDeviceDescriptor? GetDescriptor(Native.LibUsbDevice device)
        {
            if (Native.LibUsb1.libusb_get_device_descriptor(device, out var descriptor) != 0)
            {
                return null;
            }
            return descriptor;
        }

        static IMtkUsbDevice[] Find()
        {
            if (!m_context.HasValue)
            {
                throw new Exception("Failed to initialize libusb");
            }
            Native.Ptr<Native.LibUsbDevice> list;
            int count = Native.LibUsb1.libusb_get_device_list(m_context.Value, out list).ToInt32();
            try
            {
                Native.LibUsbDevice[] array = list.Get(count);
                List<MtkUsbDevice> list2 = new List<MtkUsbDevice>();
                for (int i = 0; i < array.Length; i++)
                {
                    Native.LibUsbDeviceDescriptor? descriptor = GetDescriptor(array[i]);
                    if (
                        descriptor.HasValue
                        && descriptor.Value.IdVendor == 3725
                        && descriptor.Value.IdProduct == 3
                    )
                    {
                        list2.Add(new MtkUsbDevice(m_context.Value, array[i], descriptor.Value));
                    }
                }
                return list2.ToArray();
            }
            finally
            {
                Native.LibUsb1.libusb_free_device_list(list, 0);
            }
        }

        public static Task<IMtkUsbDevice[]> FindAsync()
        {
            return Task.Run((Func<IMtkUsbDevice[]>)Find);
        }
    }
}
