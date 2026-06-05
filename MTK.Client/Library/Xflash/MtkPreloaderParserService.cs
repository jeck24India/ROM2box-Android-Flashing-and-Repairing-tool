using System;
using System.Linq;
using System.Text;

using mtkclient.library;
using mtkclient.devicehandler;
using mtkclient.library.xflash;

namespace mtkclient.library.xflash
{
    internal class MtkPreloaderParserService
    {
        public static MtkPreloaderEmi ParseEmi(byte[] data, bool isXFlash)
        {
            int num = data.Find(new byte[8] { 77, 77, 77, 1, 56, 0, 0, 0 });
            if (num == -1)
            {
                throw new Exception("Unable to find preloader index");
            }
            data = data.Skip(num).ToArray();
            int count = BitConverter.ToInt32(data, 32);
            int num2 = BitConverter.ToInt32(data, 44);
            data = data.Take(count).ToArray();
            num = data.Find(Encoding.ASCII.GetBytes("MTK_BLOADER_INFO_v"));
            if (num == -1)
            {
                throw new Exception("EMI index not found");
            }
            data = data.Skip(num).ToArray();
            if (
                uint.TryParse(
                    Encoding.ASCII.GetString(data, "MTK_BLOADER_INFO_v".Length, 2),
                    out var result
                )
            )
            {
                byte[] array = data.Take(data.Length - num2).ToArray();
                if (array.Length - 4 > 4)
                {
                    int num3 = BitConverter.ToInt32(array, array.Length - 4);
                    if (num3 != array.Length - 4)
                    {
                        throw new Exception("Invalid EMI length");
                    }
                    array = array.Take(num3).ToArray();
                    if (!isXFlash)
                    {
                        int num4 = array.Find(Encoding.ASCII.GetBytes("MTK_BIN"));
                        if (num4 != -1)
                        {
                            array = array.Skip(num4 + 12).ToArray();
                        }
                    }
                    return new MtkPreloaderEmi(result, array);
                }
                throw new Exception("EMI too short");
            }
            throw new Exception("Unable to parse EMI version");
        }

        public static MtkPreloaderIndex ParseIndex(byte[] data)
        {
            int num = data.Find(new byte[8] { 77, 77, 77, 1, 56, 0, 0, 0 });
            if (num == -1)
            {
                throw new Exception("Unable to find preloader index");
            }
            data = data.Skip(num).ToArray();
            int length = BitConverter.ToInt32(data, 32);
            return new MtkPreloaderIndex(num, length);
        }

        public static string ParseName(byte[] data)
        {
            int num = data.Find(Encoding.ASCII.GetBytes("MTK_BLOADER_INFO"));
            byte[] bytes = data.Skip(num + 27).Take(48).ToArray();
            return Encoding.ASCII.GetString(bytes).TrimEnd(default(char));
        }
    }
}
