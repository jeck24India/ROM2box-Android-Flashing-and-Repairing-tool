using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace mtkclient.library
{
    internal class MtkDaxUploadCalculatorService
    {
        static (int HashMode, int Index) CalculateDaHash(byte[] da1Buff, byte[] da2Buff)
        {
            byte[] needle;
            using (SHA1 sHA = SHA1.Create())
            {
                needle = sHA.ComputeHash(da2Buff);
            }
            byte[] needle2;
            using (SHA256 sHA2 = SHA256.Create())
            {
                needle2 = sHA2.ComputeHash(da2Buff);
            }
            int num = da1Buff.Find(needle);
            int item = 1;
            if (num == -1)
            {
                num = da1Buff.Find(needle2);
                item = 2;
            }
            return (item, num);
        }

        static (int HashMode, int Index, int Length)? CalculateHash(
            byte[] da1,
            byte[] da2,
            int da2SignatureLen
        )
        {
            int num = da2.Length - da2SignatureLen;
            (int, int) tuple = CalculateDaHash(da1, da2.Take(num).ToArray());
            if (tuple.Item2 == -1)
            {
                num = da2.Length;
                tuple = CalculateDaHash(da1, da2);
                if (tuple.Item2 == -1)
                {
                    return null;
                }
            }
            return (tuple.Item1, tuple.Item2, num);
        }

        static byte[] FixHash(byte[] da1, byte[] da2, int hashPos, int hashMode, int hashLen)
        {
            HashAlgorithm hashAlgorithm;
            if (hashMode == 1)
            {
                hashAlgorithm = SHA1.Create();
            }
            else
            {
                if (hashMode != 2)
                {
                    throw new ArgumentException("Unknown hash mode");
                }
                hashAlgorithm = SHA256.Create();
            }
            byte[] array;
            using (hashAlgorithm)
            {
                array = hashAlgorithm.ComputeHash(da2.Take(hashLen).ToArray());
            }
            using (MemoryStream memoryStream = new MemoryStream(da1))
            {
                memoryStream.Seek(hashPos, SeekOrigin.Begin);
                memoryStream.Write(array, 0, array.Length);
                return memoryStream.ToArray();
            }
        }

        public static MtkDaxUploadCalculationResult Calculate(
            byte[] da1,
            byte[] da2,
            uint uint_0,
            int da2SignatureLen
        )
        {
            (int, int, int)? tuple = CalculateHash(da1, da2, da2SignatureLen);
            if (tuple.HasValue)
            {
                da2 = MtkDaxUploadPatchService.Patch2(da2);
                da1 = FixHash(da1, da2, tuple.Value.Item2, tuple.Value.Item1, tuple.Value.Item3);
                da2 = da2.Take(tuple.Value.Item3).ToArray();
            }
            else
            {
                da2 = da2.Take(da2.Length - da2SignatureLen).ToArray();
            }
            byte[] extension = MtkDaxUploadPatchService.PatchExtension(da2, (int)uint_0);

            Console.WriteLine("da_x.bin writen");
            return new MtkDaxUploadCalculationResult(da1, da2, extension);
        }
    }
}
