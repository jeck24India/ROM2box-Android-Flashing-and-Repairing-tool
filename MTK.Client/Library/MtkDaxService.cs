using mtkclient;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using mtkclient.library;
using mtkclient.library.xflash;

namespace mtkclient.library
{
    internal class MtkDaxService
    {
        public static async Task<byte[]> ReadAsync(
            IMtkDevice device,
            CancellationToken cancellationToken
        )
        {
            uint magic = await device.ReadDwordAsync(little: false, cancellationToken);
            await device.ReadDwordAsync(little: false, cancellationToken);
            uint num = await device.ReadDwordAsync(little: false, cancellationToken);
            if (magic != 4277071599u)
            {
                throw new Exception($"Invalid DAX magic: 0x{magic:X8}");
            }
            byte[] result = new byte[num];
            await device.ReadExactAsync(result, 0, (int)num, cancellationToken);
            return result;
        }

        public static async Task<uint> ReadStatusAsync(
            IMtkDevice device,
            CancellationToken cancellationToken
        )
        {
            byte[] array = await ReadAsync(device, cancellationToken);
            if (array.Length == 2)
            {
                return BitConverter.ToUInt16(array, 0);
            }
            if (array.Length < 4)
            {
                throw new Exception("Invalid DAX status buffer length: " + array.Length);
            }
            uint num = BitConverter.ToUInt32(array, 0);
            if (num == 4277071599u)
            {
                return 0u;
            }
            return num;
        }

        public static async Task<uint> ReadAckAsync(
            IMtkDevice device,
            CancellationToken cancellationToken
        )
        {
            await SendAsync(device, 0u, cancellationToken);
            return await ReadStatusAsync(device, cancellationToken);
        }

        public static async Task SendAsync(
            IMtkDevice device,
            byte[] data,
            int bufferSize,
            CancellationToken cancellationToken
        )
        {
            using (MemoryStream requestStream = new MemoryStream())
            {
                requestStream.Write(BitConverter.GetBytes(4277071599u));
                requestStream.Write(BitConverter.GetBytes(1));
                requestStream.Write(BitConverter.GetBytes(data.Length));
                byte[] array = requestStream.ToArray();
                await device.WriteAsync(array, 0, array.Length, cancellationToken);
                int sent = 0;
                byte[] sendBuff = new byte[bufferSize];
                int toSend;
                for (; sent < data.Length; sent += toSend)
                {
                    toSend = Math.Min(sendBuff.Length, data.Length - sent);
                    Array.Copy(data, sent, sendBuff, 0, toSend);
                    await device.WriteAsync(sendBuff, 0, toSend, cancellationToken);
                }
            }
        }

        public static Task SendAsync(
            IMtkDevice device,
            byte[] data,
            CancellationToken cancellationToken
        )
        {
            return SendAsync(device, data, 512, cancellationToken);
        }

        public static Task SendAsync(
            IMtkDevice device,
            uint data,
            CancellationToken cancellationToken
        )
        {
            return SendAsync(device, BitConverter.GetBytes(data), cancellationToken);
        }
    }
}
