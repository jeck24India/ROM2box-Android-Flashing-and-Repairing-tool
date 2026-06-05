using System;
using System.Threading;
using System.Threading.Tasks;

using mtkclient.devicehandler;

namespace mtkclient.library.xflash
{
    internal class MtkDeviceWaiterService
    {
        public static async Task<MtkDeviceWaitResult> WaitSerialAsync(
            bool doHandshake,
            CancellationToken cancellationToken
        )
        {
            int current = -1;
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                int num = current + 1;
                current = num;
                if (current != 180)
                {
                    IMtkSerialDevice[] devices = await MtkSerialDeviceFinderService.FindAsync();
                    if (devices.Length != 0)
                    {
                        if (devices.Length <= 1)
                        {
                            LogService.Information(
                                "Single mtk serial device found: {0}",
                                devices[0].ToString()
                            );
                            try
                            {
                                LogService.Information("Connecting to mtk serial device");
                                await devices[0].ConnectAsync();
                            }
                            catch (Exception exception)
                            {
                                devices[0].Dispose();
                                LogService.Information(
                                    exception.ToString(),
                                    "Error connecting to mtk serial device"
                                );
                                await Task.Delay(TimeSpan.FromSeconds(1.0));
                                continue;
                            }
                            bool isBootloader;
                            MtkDeviceInfo deviceInfo;
                            if (doHandshake)
                            {
                                try
                                {
                                    LogService.Information("Doing mtk handshake");
                                    isBootloader = await MtkHandshakeService.DoHandshakeAsync(
                                        devices[0],
                                        cancellationToken
                                    );
                                    LogService.Information("Getting mtk device info");
                                    deviceInfo = await MtkHandshakeService.GetDeviceInfoAsync(
                                        devices[0],
                                        cancellationToken
                                    );
                                }
                                catch (Exception exception2)
                                {
                                    devices[0].Dispose();
                                    LogService.Information(
                                        exception2.ToString(),
                                        "Error doing mtk handshake"
                                    );
                                    await Task.Delay(TimeSpan.FromSeconds(1.0));
                                    continue;
                                }
                            }
                            else
                            {
                                isBootloader = false;
                                deviceInfo = new MtkDeviceInfo(
                                    0u,
                                    0u,
                                    IsSecure: false,
                                    "",
                                    new MtkChipConfig()
                                );
                            }
                            return new MtkDeviceWaitResult(devices[0], isBootloader, deviceInfo);
                        }
                        IMtkSerialDevice[] array = devices;
                        for (num = 0; num < array.Length; num++)
                        {
                            array[num].Dispose();
                        }
                        LogService.Information("Multiple mtk serial devices found. Retrying");
                        //if (
                        //    (
                        //        await m_dialogService.ShowAsync(
                        //            "confirmation",
                        //            "connect_only_one_device",
                        //            new MessageDialogAction[2]
                        //            {
                        //                new MessageDialogAction { Name = "ok" },
                        //                new MessageDialogAction { Name = "cancel" }
                        //            }
                        //        )
                        //    ).Name == "cancel"
                        //)
                        //{
                        //    break;
                        //}
                        await Task.Delay(TimeSpan.FromSeconds(1.0));
                    }
                    else
                    {
                        await Task.Delay(TimeSpan.FromSeconds(1.0));
                    }
                    continue;
                }
                throw new TimeoutException();
            }
            throw new TaskCanceledException();
        }

        public static async Task<MtkDeviceWaitResult> WaitUsbAsync(
            bool doHandshake,
            CancellationToken cancellationToken
        )
        {
            int current = -1;
            IMtkUsbDevice[] devices;
            bool isBootloader;
            MtkDeviceInfo deviceInfo;
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                int num = current + 1;
                current = num;
                if (current != 180)
                {
                    devices = await MtkUsbDeviceFinderService.FindAsync();
                    if (devices.Length == 0)
                    {
                        await Task.Delay(TimeSpan.FromSeconds(1.0));
                        continue;
                    }
                    if (devices.Length > 1)
                    {
                        IMtkUsbDevice[] array = devices;
                        for (num = 0; num < array.Length; num++)
                        {
                            array[num].Dispose();
                        }
                        LogService.Information("Multiple mtk usb devices found. Retrying");
                        //if (
                        //    (
                        //        await m_dialogService.ShowAsync(
                        //            "confirmation",
                        //            "connect_only_one_device",
                        //            new MessageDialogAction[2]
                        //            {
                        //                new MessageDialogAction { Name = "ok" },
                        //                new MessageDialogAction { Name = "cancel" }
                        //            }
                        //        )
                        //    ).Name == "cancel"
                        //)
                        //{
                        //    throw new TaskCanceledException();
                        //}
                        await Task.Delay(TimeSpan.FromSeconds(1.0));
                        continue;
                    }
                    LogService.Information(
                        "Single mtk usb device found: {0}",
                        devices[0].ToString()
                    );
                    try
                    {
                        LogService.Information("Connecting to mtk usb device");
                        await devices[0].ConnectAsync();
                    }
                    catch (Exception exception)
                    {
                        devices[0].Dispose();
                        LogService.Information(
                            exception.ToString(),
                            "Error connecting to mtk usb device"
                        );
                        await Task.Delay(TimeSpan.FromSeconds(1.0));
                        continue;
                    }
                    if (doHandshake)
                    {
                        try
                        {
                            LogService.Information("Doing mtk handshake");
                            isBootloader = await MtkHandshakeService.DoHandshakeAsync(
                                devices[0],
                                cancellationToken
                            );
                            LogService.Information("Gettting mtk device info");
                            deviceInfo = await MtkHandshakeService.GetDeviceInfoAsync(
                                devices[0],
                                cancellationToken
                            );
                        }
                        catch (Exception exception2)
                        {
                            devices[0].Dispose();
                            LogService.Information(
                                exception2.ToString(),
                                "Error doing mtk handshake"
                            );
                            await Task.Delay(TimeSpan.FromSeconds(1.0));
                            continue;
                        }
                    }
                    else
                    {
                        isBootloader = false;
                        deviceInfo = new MtkDeviceInfo(
                            0u,
                            0u,
                            IsSecure: false,
                            "",
                            new MtkChipConfig()
                        );
                    }
                    break;
                }
                throw new TimeoutException();
            }
            return new MtkDeviceWaitResult(devices[0], isBootloader, deviceInfo);
        }
    }
}
