using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using mtkclient;

namespace mtkclient.library
{
    internal class MtkDaxUploadBootService
    {
        public static async Task BootToAsync(
            IMtkDevice device,
            long address,
            byte[] da,
            CancellationToken cancellationToken
        )
        {
            LogService.Information("Sending boot command: 0x010008");
            await MtkDaxService.SendAsync(device, 65544u, cancellationToken);
            LogService.Information("Reading boot command status");
            uint num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
            if (num != 0)
            {
                throw new Exception($"Invalid boot command status: 0x{num:X8}");
            }
            LogService.Information(
                "Sending boot parameter: address 0x{0:X16} length {1}",
                address,
                da.Length
            );
            using (MemoryStream bootParamStream = new MemoryStream())
            {
                bootParamStream.Write(BitConverter.GetBytes(address));
                bootParamStream.Write(BitConverter.GetBytes((long)da.Length));
                await MtkDaxService.SendAsync(device, bootParamStream.ToArray(), cancellationToken);
                LogService.Information("Sending boot DA");
                await MtkDaxService.SendAsync(device, da, 64, cancellationToken);
                LogService.Information("Reading boot DA status");
                num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
                if (num == 0)
                {
                    LogService.Information("Delay for 500ms");
                    await Task.Delay(TimeSpan.FromMilliseconds(500.0));
                    LogService.Information("Reading boot status");
                    num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
                    LogService.Information("Boot status: 0x{0:X8}", num);
                    if (num != 0 && num != 1129208147)
                    {
                        throw new Exception($"Invalid boot status: 0x{num:X8}");
                    }
                    return;
                }
                throw new Exception($"Invalid boot DA status: 0x{num:X8}");
            }
        }

        public static async Task RebootAsync(IMtkDevice device, CancellationToken cancellationToken)
        {
            LogService.Information("Sending boot command: 0x010007");
            await MtkDaxService.SendAsync(device, 65543u, cancellationToken);
            LogService.Information("Reading command status");
            uint num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
            if (num == 0)
            {
                LogService.Information("Sending boot command param");
                using (MemoryStream payloadStream = new MemoryStream(24))
                {
                    payloadStream.Write(BitConverter.GetBytes(1));
                    payloadStream.Write(BitConverter.GetBytes(29098084));
                    payloadStream.Write(BitConverter.GetBytes(0));
                    payloadStream.Write(BitConverter.GetBytes(0));
                    payloadStream.Write(BitConverter.GetBytes(0));
                    payloadStream.Write(BitConverter.GetBytes(0));
                    await MtkDaxService.SendAsync(
                        device,
                        payloadStream.ToArray(),
                        cancellationToken
                    );
                    LogService.Information("Reading param status");
                    num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
                    if (num != 0)
                    {
                        throw new Exception($"Invalid boot command param status: 0x{num:X8}");
                    }
                    return;
                }
                throw new Exception($"Invalid boot command status: 0x{num:X8}");
            }
        }
    }
}
