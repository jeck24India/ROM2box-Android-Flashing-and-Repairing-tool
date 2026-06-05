using SparseConverter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mtkclient.library
{
    class MtkSparse
    {
        private static int totalchunk { get; set; }
        private static MTK_SPARSE_HEADER sparseheader;
        private const Int64 MTK_SPARSE_MAGIC = unchecked((int)0xEED26FF3A);
        private const Int64 MTK_SPARSE_RAW_CHUNK = 0xECAC1;
        private const Int64 MTK_SPARSE_FILL_CHUNK = 0xECAC2;
        private const Int64 MTK_SPARSE_DONT_CARE = 0xECAC3;

        public struct MTK_CHUNK_HEADER
        {
            public Int16 wChunkType;
            public Int16 wReserved;
            public Int32 dwChunkSize;
            public Int32 dwTotalSize;
        }

        public struct MTK_SPARSE_HEADER
        {
            public Int32 dwMagic; //4
            public Int16 wVerMajor; //2
            public Int16 wVerMinor; //2
            public Int16 wSparseHeaderSize; //2
            public Int16 wChunkHeaderSize; //2
            public Int32 dwBlockSize; //4
            public Int32 dwTotalBlocks; //4
            public Int32 dwTotalChunks;
            public Int32 dwImageChecksum;
        }

        public static bool CekSparse(string files)
        {
            long header_magic;
            Stream stream = File.OpenRead(files);
            stream.Seek(0L, SeekOrigin.Begin);

            byte[] buffer = new byte[1025];
            using (BinaryReader reader = new BinaryReader(stream))
            {
                reader.Read(buffer, 0, 28);
                sparseheader = parsingheader(buffer);
                var magic = sparseheader.dwMagic;
                header_magic = Convert.ToInt64(magic);
                if (header_magic == MTK_SPARSE_MAGIC)
                {
                    totalchunk = sparseheader.dwTotalChunks;
                    stream.Close();
                    reader.Close();
                    return true;
                }
                else
                {
                    stream.Close();
                    reader.Close();
                    return false;
                }
            }
        }

        public static MTK_SPARSE_HEADER parsingheader(byte[] bytes)
        {
            MTK_SPARSE_HEADER stuff = new MTK_SPARSE_HEADER();
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                stuff = (MTK_SPARSE_HEADER)
                    Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(MTK_SPARSE_HEADER));
            }
            finally
            {
                handle.Free();
            }
            return stuff;
        }

        public static List<string> GetSparseList(string inputPath)
        {
            List<string> sparseList = new List<string>();
            sparseList.Add(inputPath);
            if (inputPath.EndsWith("0") || inputPath.EndsWith("1"))
            {
                int firstSparseIndex = Convert.ToInt32(inputPath.Substring(inputPath.Length - 1));
                string prefix = inputPath.Substring(0, inputPath.Length - 1);
                int sparseIndex = firstSparseIndex + 1;
                string sparsePath = prefix + sparseIndex.ToString();
                while (File.Exists(sparsePath))
                {
                    sparseList.Add(sparsePath);
                    sparseIndex++;
                    sparsePath = prefix + sparseIndex.ToString();
                }
            }

            return sparseList;
        }

        public static void Decompress(List<string> sparseList, FileStream output)
        {
            output.SetLength(0);

            foreach (string sparsePath in sparseList)
            {
                FileStream input;
                input = File.Open(sparsePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                Console.WriteLine("Processing: {0}", sparsePath);

                SparseDecompressionHelper.DecompressSparse(input, output);
            }
        }
    }
}
