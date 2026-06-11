using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace mtkclient.library.xflash
{
    internal static class MtkDeviceExtension
    {
        public static async Task ReadExactAsync(
            this IMtkDevice device,
            byte[] buff,
            int offset,
            int len,
            CancellationToken cancellationToken
        )
        {
            int totalRead = 0;
            while (true)
            {
                if (totalRead < len)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    int num = await device.ReadAsync(
                        buff,
                        totalRead + offset,
                        len - totalRead,
                        cancellationToken
                    );
                    if (num == 0)
                    {
                        break;
                    }
                    totalRead += num;
                    continue;
                }
                return;
            }
            throw new Exception("Unexpected device EOF");
        }

        public static async Task<uint> ReadDwordAsync(
            this IMtkDevice device,
            bool little,
            CancellationToken cancellationToken
        )
        {
            byte[] buff = new byte[4];
            await device.ReadExactAsync(buff, 0, buff.Length, cancellationToken);
            if (little)
            {
                buff = buff.Reverse().ToArray();
            }
            return BitConverter.ToUInt32(buff, 0);
        }

        public static async Task<ushort> ReadWordAsync(
            this IMtkDevice device,
            bool little,
            CancellationToken cancellationToken
        )
        {
            byte[] buff = new byte[2];
            await device.ReadExactAsync(buff, 0, buff.Length, cancellationToken);
            if (little)
            {
                buff = buff.Reverse().ToArray();
            }
            return BitConverter.ToUInt16(buff, 0);
        }

        public static async Task<byte> ReadByteAsync(
            this IMtkDevice device,
            CancellationToken cancellationToken
        )
        {
            byte[] buff = new byte[1];
            await device.ReadExactAsync(buff, 0, buff.Length, cancellationToken);
            return buff[0];
        }

        public static async Task EchoAsync(
            this IMtkDevice device,
            byte[] buff,
            CancellationToken cancellationToken
        )
        {
            await device.WriteAsync(buff, 0, buff.Length, cancellationToken);
            byte[] responseBuff = new byte[buff.Length];
            await device.ReadExactAsync(responseBuff, 0, responseBuff.Length, cancellationToken);
            if (!buff.SequenceEqual(responseBuff))
            {
                throw new Exception(
                    $"Invalid device echo response. Expected: {BitConverter.ToString(buff)}. Got: {BitConverter.ToString(responseBuff)}"
                );
            }
        }

        public static Task EchoAsync(
            this IMtkDevice device,
            byte buff,
            CancellationToken cancellationToken
        )
        {
            return device.EchoAsync(new byte[1] { buff }, cancellationToken);
        }
    }
}
