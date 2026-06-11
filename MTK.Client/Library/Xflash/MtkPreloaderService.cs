using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using mtkclient;

using mtkclient.library;
using mtkclient.devicehandler;
using mtkclient.library.xflash;

namespace mtkclient.library.xflash
{
    internal class MtkPreloaderService
    {
        static byte[] ConvertDwordsToByteArray(uint[] dwords)
        {
            using (MemoryStream memoryStream = new MemoryStream(dwords.Length * 4))
            {
                for (int i = 0; i < dwords.Length; i++)
                {
                    byte[] bytes = BitConverter.GetBytes(dwords[i]);
                    memoryStream.Write(bytes, 0, bytes.Length);
                }
                return memoryStream.ToArray();
            }
        }

        public static async Task<MtkPreloader> DumpAsync(
            IMtkDevice device,
            MtkChipConfig chipConfig,
            CancellationToken cancellationToken
        )
        {
            LogService.Information("Getting preloader index");
            byte[] data = ConvertDwordsToByteArray(
                await MtkReadWrite32Service.ReadResultAsync(
                    device,
                    2097152u,
                    16384,
                    little: true,
                    cancellationToken
                )
            );
            MtkPreloaderIndex index = MtkPreloaderParserService.ParseIndex(data);
            LogService.Information("Preloader index: {0}", index.ToString());
            LogService.Information("Delay for 150 ms");
            await Task.Delay(TimeSpan.FromMilliseconds(150.0));
            LogService.Information("Start dumping preloader data. Size: {0}", index.Length);
            using (MemoryStream preloaderStream = new MemoryStream())
            {
                int currentIndex = index.Index;
                int multiplier = 32;
                int maxProgress = index.Length + multiplier * 16;
                Main.SharedUI.label_totalsize.Invoke(
                    (Action)(
                        () =>
                            Main.SharedUI.label_totalsize.Text = Extension.GetFileSize(index.Length)
                    )
                );

                var Stopwatch = new Stopwatch();
                Stopwatch.Start();

                while (currentIndex - index.Index <= index.Length)
                {
                    uint num = (uint)(2097152 + currentIndex);

                    Main.SharedUI.label_writensize.Invoke(
                        (Action)(
                            () =>
                                Main.SharedUI.label_writensize.Text = Extension.GetFileSize(
                                    currentIndex
                                )
                        )
                    );

                    TimeSpan elapsed = Stopwatch.Elapsed;
                    double speed = currentIndex / elapsed.TotalSeconds;
                    Main.SharedUI.label_transferrate.Invoke(
                        (Action)(
                            () =>
                                Main.SharedUI.label_transferrate.Text =
                                    Extension.GetFileSize(Convert.ToInt64(speed)) + " /s"
                        )
                    );

                    Main.ProcessBar(currentIndex, index.Length);
                    data = ConvertDwordsToByteArray(
                        await MtkReadWrite32Service.ReadResultAsync(
                            device,
                            num,
                            multiplier * 4,
                            little: true,
                            cancellationToken
                        )
                    );
                    await preloaderStream.WriteAsync(data, 0, data.Length);
                    currentIndex += multiplier * 16;
                }
                Stopwatch.Stop();
                LogService.Information(
                    "Done dumping preloader data. Size: {0}",
                    preloaderStream.Length
                );
                preloaderStream.Seek(0L, SeekOrigin.Begin);
                return await LoadAsync(preloaderStream, chipConfig, cancellationToken);
            }
        }

        public static async Task<MtkPreloader> LoadAsync(
            Stream preloaderStream,
            MtkChipConfig chipConfig,
            CancellationToken cancellationToken
        )
        {
            byte[] preloaderBuff = new byte[(int)preloaderStream.Length];
            await preloaderStream.ReadAsync(
                preloaderBuff,
                0,
                preloaderBuff.Length,
                cancellationToken
            );
            string name = MtkPreloaderParserService.ParseName(preloaderBuff);
            MtkPreloaderEmi mtkPreloaderEmi = MtkPreloaderParserService.ParseEmi(
                preloaderBuff,
                chipConfig.UseXFlash
            );
            return new MtkPreloader(
                name,
                mtkPreloaderEmi.Version,
                mtkPreloaderEmi.Emi,
                preloaderBuff
            );
        }
    }
}
