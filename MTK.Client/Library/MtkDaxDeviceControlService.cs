using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using mtkclient;

namespace mtkclient.library
{
    internal class MtkDaxDeviceControlService
    {
        public static async Task<byte[]> SendDevCtrlAsync(
            IMtkDevice device,
            uint cmd,
            CancellationToken cancellationToken
        )
        {
            if (await SendDevCtrlNoReadAsync(device, cmd, cancellationToken))
            {
                LogService.Information("Reading dev ctrl result");
                byte[] result = await MtkDaxService.ReadAsync(device, cancellationToken);
                LogService.Information("Reading dev ctrl result status");
                uint num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
                if (num != 0)
                {
                    throw new Exception($"Invalid dev ctrl result status: 0x{num:X8}");
                }
                return result;
            }
            return new byte[0];
        }

        public static async Task SendDevCtrlAsync(
            IMtkDevice device,
            uint cmd,
            byte[] param,
            CancellationToken cancellationToken
        )
        {
            if (await SendDevCtrlNoReadAsync(device, cmd, cancellationToken))
            {
                LogService.Information("Sending dev ctrl param: {0}", BitConverter.ToString(param));
                await MtkDaxService.SendAsync(device, param, cancellationToken);
                LogService.Information("Reading dev ctrl param status");
                uint num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
                if (num != 0)
                {
                    throw new Exception($"Invalid dev ctrl param status: 0x{num:X8}");
                }
            }
        }

        public static async Task<bool> SendDevCtrlNoReadAsync(
            IMtkDevice device,
            uint cmd,
            CancellationToken cancellationToken
        )
        {
            await MtkDaxService.SendAsync(device, 65545u, cancellationToken);
            uint num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
            if (num != 0)
            {
                throw new Exception($"Invalid dev ctrl cmd status: 0x{num:X8}");
            }
            await MtkDaxService.SendAsync(device, cmd, cancellationToken);
            num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
            switch (num)
            {
                case 0u:
                    return true;
                default:
                    throw new Exception($"Invalid cmd status: 0x{num:X8}");
                case 3221291012u:
                    return false;
            }
        }
    }
}
