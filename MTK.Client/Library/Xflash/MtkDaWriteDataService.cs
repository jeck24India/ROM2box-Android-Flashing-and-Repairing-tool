using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace mtkclient.library.xflash
{
    internal class MtkDaWriteDataService
    {
        public static void PrepareData(
            byte[] da,
            int signatureLength,
            out ushort checksum,
            out byte[] buffer
        )
        {
            checksum = 0;
            buffer = da;
            if (buffer.Length % 2 != 0)
            {
                buffer = ((IEnumerable<byte>)buffer).Append((byte)0).ToArray();
            }
            for (int i = 0; i < buffer.Length; i += 2)
            {
                checksum ^= BitConverter.ToUInt16(buffer, i);
            }
            if (((uint)buffer.Length & (true ? 1u : 0u)) != 0)
            {
                checksum ^= buffer.Last();
            }
        }
    }
}
