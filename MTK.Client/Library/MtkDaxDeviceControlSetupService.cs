using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mtkclient.library
{
    internal class MtkDaxDeviceControlSetupService
    {
        public static async Task<string> GetConnectionAgentAsync(
            IMtkDevice device,
            CancellationToken cancellationToken
        )
        {
            byte[] bytes = await MtkDaxDeviceControlService.SendDevCtrlAsync(
                device,
                262154u,
                cancellationToken
            );
            return Encoding.ASCII.GetString(bytes);
        }

        public static async Task<string> GetExpireDateAsync(
            IMtkDevice device,
            CancellationToken cancellationToken
        )
        {
            byte[] bytes = await MtkDaxDeviceControlService.SendDevCtrlAsync(
                device,
                262161u,
                cancellationToken
            );
            return Encoding.ASCII.GetString(bytes);
        }

        public static async Task<string> GetUsbSpeedAsync(
            IMtkDevice device,
            CancellationToken cancellationToken
        )
        {
            byte[] bytes = await MtkDaxDeviceControlService.SendDevCtrlAsync(
                device,
                262155u,
                cancellationToken
            );
            return Encoding.ASCII.GetString(bytes);
        }

        public static async Task SendCustomAckAsync(
            IMtkDevice device,
            CancellationToken cancellationToken
        )
        {
            uint num = BitConverter.ToUInt32(
                await MtkDaxDeviceControlService.SendDevCtrlAsync(
                    device,
                    983040u,
                    cancellationToken
                ),
                0
            );
            if (num != 2711790500u)
            {
                throw new Exception($"Invalid custom ack response: 0x{num:X8}");
            }
        }

        public static async Task SetChecksumLevelAsync(
            IMtkDevice device,
            uint level,
            CancellationToken cancellationToken
        )
        {
            await MtkDaxDeviceControlService.SendDevCtrlAsync(
                device,
                131075u,
                BitConverter.GetBytes(level),
                cancellationToken
            );
        }

        public static async Task SetResetKeyAsync(
            IMtkDevice device,
            uint resetKey,
            CancellationToken cancellationToken
        )
        {
            await MtkDaxDeviceControlService.SendDevCtrlAsync(
                device,
                131076u,
                BitConverter.GetBytes(resetKey),
                cancellationToken
            );
        }
    }
}
