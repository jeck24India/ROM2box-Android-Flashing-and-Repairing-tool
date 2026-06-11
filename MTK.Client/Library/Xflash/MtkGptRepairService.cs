using Force.Crc32;
using System;
using System.IO;

using System.Text;

namespace mtkclient.library.xflash
{
    internal class MtkGptRepairService
    {
        static byte[] FixHeader(byte[] data, int pageSize)
        {
            byte[] array = new byte[8];
            Array.Copy(data, 32, array, 0, array.Length);
            byte[] array2 = new byte[8];
            Array.Copy(data, 24, array2, 0, array2.Length);
            byte[] bytes = BitConverter.GetBytes(2L);
            byte[] array3 = new byte[pageSize];
            using (MemoryStream memoryStream = new MemoryStream(array3))
            {
                memoryStream.Write(data, 0, 8);
                memoryStream.Write(data, 8, 4);
                memoryStream.Write(data, 12, 4);
                memoryStream.Write(new byte[4], 0, 4);
                memoryStream.Write(new byte[4], 0, 4);
                memoryStream.Write(array, 0, 8);
                memoryStream.Write(array2, 0, 8);
                memoryStream.Write(data, 40, 8);
                memoryStream.Write(data, 48, 8);
                memoryStream.Write(data, 56, 16);
                memoryStream.Write(bytes, 0, 8);
                memoryStream.Write(data, 80, 4);
                memoryStream.Write(data, 84, 4);
                memoryStream.Write(data, 88, 4);
                uint value = Calculate(array3);
                memoryStream.Seek(16L, SeekOrigin.Begin);
                byte[] bytes2 = BitConverter.GetBytes(value);
                memoryStream.Write(bytes2, 0, 4);
                return array3;
            }
        }

        public static byte[] Fix(byte[] data, int pageSize)
        {
            using (MemoryStream memoryStream = new MemoryStream(34 * pageSize))
            {
                memoryStream.Seek(pageSize, SeekOrigin.Begin);
                memoryStream.Seek(pageSize, SeekOrigin.Begin);
                int num = data.Find(Encoding.ASCII.GetBytes("EFI PART"));
                byte[] array = new byte[pageSize];
                Array.Copy(data, num, array, 0, array.Length);
                array = FixHeader(array, pageSize);
                memoryStream.Write(array, 0, array.Length);
                byte[] array2 = new byte[32 * pageSize];
                Array.Copy(data, 0, array2, 0, num);
                memoryStream.Write(array2, 0, array2.Length);
                return memoryStream.ToArray();
            }
        }

        public static uint Calculate(byte[] data)
        {
            return Crc32Algorithm.Compute(data);
        }
    }
}
