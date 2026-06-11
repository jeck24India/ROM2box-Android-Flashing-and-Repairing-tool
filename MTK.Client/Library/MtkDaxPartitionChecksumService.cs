using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace mtkclient.library
{
    internal class MtkDaxPartitionChecksumService
    {
        public static int Calculate(byte[] payload)
        {
            return (int)((IEnumerable<byte>)payload).Sum((Func<byte, long>)((byte x) => x))
                & 0xFFFF;
        }
    }
}
