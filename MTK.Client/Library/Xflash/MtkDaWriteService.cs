using System;
using System.Threading;
using System.Threading.Tasks;
using mtkclient;

namespace mtkclient.library.xflash
{
    internal class MtkDaWriteService
    {
        public static async Task WriteAsync(
            IMtkDevice device,
            uint address,
            int signatureLength,
            byte[] da,
            bool validateUploadStatus,
            CancellationToken cancellationToken
        )
        {
            LogService.Information("Preparing da buffer");
            MtkDaWriteDataService.PrepareData(
                da,
                signatureLength,
                out var checksum,
                out var buffer
            );
            LogService.Information(
                "Buffer size: {0}; Signature size: {1} Checksum: 0x{2:X4}",
                buffer.Length,
                signatureLength,
                checksum
            );
            LogService.Information("Sending 0xD7");
            await device.EchoAsync(215, cancellationToken);
            LogService.Information("Sending address: 0x{0:X8}", address);
            byte[] bytes = BitConverter.GetBytes(address);
            Array.Reverse(bytes);
            await device.EchoAsync(bytes, cancellationToken);
            LogService.Information("Sending buffer length");
            byte[] bytes2 = BitConverter.GetBytes(buffer.Length);
            Array.Reverse(bytes2);
            await device.EchoAsync(bytes2, cancellationToken);
            LogService.Information("Sending signature length");
            byte[] bytes3 = BitConverter.GetBytes(signatureLength);
            Array.Reverse(bytes3);
            await device.EchoAsync(bytes3, cancellationToken);
            LogService.Information("Reading status");
            ushort num = await device.ReadWordAsync(little: true, cancellationToken);
            if (num == 0)
            {
                int sent = 0;
                byte[] writeBuff = new byte[64];
                LogService.Information("Sending data with 64 byte buffer");
                int toSend;
                for (; sent < buffer.Length; sent += toSend)
                {
                    toSend = Math.Min(writeBuff.Length, buffer.Length - sent);
                    Array.Copy(buffer, sent, writeBuff, 0, toSend);
                    await device.WriteAsync(writeBuff, 0, toSend, cancellationToken);
                }
                LogService.Information("Reading checksum response");
                ushort rchecksum = await device.ReadWordAsync(little: true, cancellationToken);
                LogService.Information("Reading status");
                num = await device.ReadWordAsync(little: true, cancellationToken);
                if (rchecksum != checksum && rchecksum != 0)
                {
                    throw new Exception(
                        $"Checksum of DA upload does not match: 0x{checksum:X4} vs 0x{rchecksum:X4}"
                    );
                }
                if (validateUploadStatus && num != 0)
                {
                    throw new Exception($"Invalid DA upload status: 0x{num:X4}");
                }
                return;
            }
            throw new Exception($"Invalid status: 0x{num:X4}");
        }

        public static async Task JumpAsync(
            IMtkDevice device,
            uint address,
            CancellationToken cancellationToken
        )
        {
            LogService.Information("Sending 0xD5");
            await device.EchoAsync(213, cancellationToken);
            LogService.Information("Sending address: 0x{0:X8}", address);
            byte[] bytes = BitConverter.GetBytes(address);
            Array.Reverse(bytes);
            await device.EchoAsync(bytes, cancellationToken);
            LogService.Information("Reading status");
            ushort num = await device.ReadWordAsync(little: true, cancellationToken);
            if (num != 0)
            {
                throw new Exception($"Invalid DA jump status: 0x{num:X4}");
            }
        }
    }
}
