using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using clicktoolpro.Shared.Exceptions;
using mtkclient;

namespace mtkclient.library.xflash
{
    internal class MtkHandshakeService
    {
        public static async Task<bool> DoHandshakeAsync(
            IMtkDevice device,
            CancellationToken cancellationToken
        )
        {
            byte[] SYNC = new byte[4] { 160, 10, 80, 5 };
            bool isBootloader = false;
            int errorCount = 0;
            int syncIndex = 0;
            while (syncIndex < SYNC.Length)
            {
                LogService.Information(
                    "Sending handshake: index={0}; char=0x{1:X2}",
                    syncIndex,
                    SYNC[syncIndex]
                );
                await device.WriteAsync(SYNC, syncIndex, 1, cancellationToken);
                byte b = await device.ReadByteAsync(cancellationToken);
                int num;
                if (b == 82)
                {
                    LogService.Information("Consuming EADY");
                    byte[] eadyBuff = new byte[4];
                    await device.ReadExactAsync(eadyBuff, 0, eadyBuff.Length, cancellationToken);
                    string @string = Encoding.ASCII.GetString(eadyBuff);
                    if (@string != "EADY")
                    {
                        throw new Exception("Invalid sync EADY: " + @string);
                    }
                    LogService.Information("Retry handshake from beginning. Bootloader detected");
                    syncIndex = -1;
                    isBootloader = true;
                }
                else if (b != (byte)(~SYNC[syncIndex]))
                {
                    if (errorCount >= 100)
                    {
                        throw new Exception(
                            $"Invalid sync response at {syncIndex}: 0x{(byte)(~SYNC[syncIndex]):X2} vs 0x{b:X2}"
                        );
                    }
                    num = errorCount + 1;
                    errorCount = num;
                    num = syncIndex - 1;
                    syncIndex = num;
                    LogService.Information("Handshake error count: {0}", errorCount);
                }
                num = syncIndex + 1;
                syncIndex = num;
            }
            return isBootloader;
        }

        public static async Task<MtkDeviceInfo> GetDeviceInfoAsync(
            IMtkDevice device,
            CancellationToken cancellationToken
        )
        {
            LogService.Information("Reading hardware code");
            await device.EchoAsync(253, cancellationToken);
            ushort hwCode = await device.ReadWordAsync(little: true, cancellationToken);
            LogService.Information("Hardware code: 0x{0:X4}", hwCode);
            ushort propertyValue = await device.ReadWordAsync(little: true, cancellationToken);
            LogService.Information("Hardware code read status: 0x{0:X4}", propertyValue);
            MtkChipConfig chipConfig = MtkChipConfig.ChipConfigs
                .Where((MtkChipConfig x) => x.HardwareCode == hwCode)
                .FirstOrDefault();

            if (!(chipConfig == null))
            {
                LogService.Information("Reading software version");
                await device.EchoAsync(252, cancellationToken);
                await device.ReadWordAsync(little: false, cancellationToken);
                ushort hwVer = await device.ReadWordAsync(little: true, cancellationToken);
                ushort swVer = await device.ReadWordAsync(little: true, cancellationToken);
                ushort propertyValue2 = await device.ReadWordAsync(little: true, cancellationToken);
                LogService.Information("Software version read status: 0x{0:X4}", propertyValue2);
                LogService.Information("Reading security config");
                await device.EchoAsync(216, cancellationToken);
                uint secConfig = await device.ReadDwordAsync(little: true, cancellationToken);
                ushort propertyValue3 = await device.ReadWordAsync(little: true, cancellationToken);
                LogService.Information("Security config read status: 0x{0:X4}", propertyValue3);
                bool flag = Convert.ToBoolean(secConfig & 1u);
                bool flag2 = Convert.ToBoolean(secConfig & 2u);
                bool flag3 = Convert.ToBoolean(secConfig & 4u);
                bool isSecure = flag2 || flag3;
                string securityLevel = "NON_SECURE";
                if (flag || flag2 || flag3)
                {
                    List<string> list = new List<string>();
                    if (flag)
                    {
                        list.Add("SBC");
                    }
                    if (flag2)
                    {
                        list.Add("SLA");
                    }
                    if (flag3)
                    {
                        list.Add("SDA");
                    }
                    securityLevel = string.Join("+", list);
                }
                return new MtkDeviceInfo(hwVer, swVer, isSecure, securityLevel, chipConfig);
            }
            throw new DeviceSecurityNotSupportedException();
        }
    }
}
