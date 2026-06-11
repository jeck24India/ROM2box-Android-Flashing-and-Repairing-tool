using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using clicktoolpro.Shared.Exceptions;
using mtkclient;

namespace mtkclient.library.xflash
{
    internal class MtkWatchdogService
    {
        public static async Task DisableAsync(
            IMtkDevice device,
            MtkChipConfig chipConfig,
            CancellationToken cancellationToken
        )
        {
            if (chipConfig.WdgAddress.HasValue)
            {
                uint num = MtkWatchdogValueCalculatorService.CalculateDisable(
                    chipConfig.WdgAddress.Value,
                    chipConfig.HardwareCode
                );
                LogService.Information("Wdg value: 0x{0:X8}", num);
                LogService.Information(
                    "Writing value to address 0x{0:X8}",
                    chipConfig.WdgAddress.Value
                );
                await MtkReadWrite32Service.WriteAsync(
                    device,
                    chipConfig.WdgAddress.Value,
                    num,
                    bigEndian: true,
                    cancellationToken
                );
                if (chipConfig.HardwareCode == 26002)
                {
                    LogService.Information("Writing 0x22000000 to address 0x10000500");
                    await MtkReadWrite32Service.WriteAsync(
                        device,
                        268436736u,
                        570425344u,
                        bigEndian: true,
                        cancellationToken
                    );
                }
                else if (chipConfig.HardwareCode == 25973 || chipConfig.HardwareCode == 25975)
                {
                    LogService.Information("Writing 0xC0000000 to address 0x2200");
                    await MtkReadWrite32Service.WriteAsync(
                        device,
                        8704u,
                        3221225472u,
                        bigEndian: true,
                        cancellationToken
                    );
                }
                return;
            }
            LogService.Information("WdgAddress is null");
            throw new DeviceSecurityNotSupportedException();
        }
    }
}
