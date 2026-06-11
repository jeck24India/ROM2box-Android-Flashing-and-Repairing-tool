using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using mtkclient;

namespace mtkclient.library
{
    internal class MtkDaxUploadEmiService
    {
        public static async Task UploadEmiAsync(
            IMtkDevice device,
            byte[] emi,
            CancellationToken cancellationToken
        )
        {
            LogService.Information("Sending upload emi command: 0x01000A");
            await MtkDaxService.SendAsync(device, 65546u, cancellationToken);
            LogService.Information("Reading upload emi command status");
            uint num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
            if (num == 0)
            {
                LogService.Information("Sending emi length: {0}", emi.Length);
                await MtkDaxService.SendAsync(device, (uint)emi.Length, cancellationToken);
                LogService.Information("Uploading emi");
                await MtkDaxService.SendAsync(device, emi, cancellationToken);
                LogService.Information("Reading upload emi status");
                num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
                if (num != 0)
                {
                    throw new Exception($"Invalid emi upload status: 0x{num:X8}");
                }
                return;
            }
            throw new Exception($"Invalid emi command status: 0x{num:X8}");
        }
    }
}
