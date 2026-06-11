using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using mtkclient.library;
using mtkclient.library.xflash;

namespace mtkclient.library
{
    internal class MtkDaxUploadSyncService
    {
        public static async Task SyncAsync(IMtkDevice device, CancellationToken cancellationToken)
        {
            LogService.Information("Reading DA sync");
            byte b = await device.ReadByteAsync(cancellationToken);
            if (b != 192)
            {
                throw new Exception($"Invalid DA sync: 0x{b:X2}");
            }
            LogService.Information("Sending DA sync: 0x434E5953");
            await MtkDaxService.SendAsync(device, 1129208147u, cancellationToken);
            LogService.Information("Setting up DA environment");
            await MtkDaxUploadSetupService.SetupEnvAsync(device, cancellationToken);
            LogService.Information("Setting up hardware init");
            await MtkDaxUploadSetupService.SetupHardwareInitAsync(device, cancellationToken);
            LogService.Information("Reading status");
            uint num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
            if (num != 1129208147)
            {
                throw new Exception($"Invalid DA sync status: 0x{num:X8}");
            }
        }
    }
}
