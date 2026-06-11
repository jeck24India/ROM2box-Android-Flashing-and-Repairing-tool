using System.IO;
using System.Linq;

using System.Threading;
using System.Threading.Tasks;

using mtkclient.library;
using mtkclient.devicehandler;
using mtkclient.library.xflash;

namespace mtkclient.library
{
    internal class MtkDaxGptService
    {
        public static async Task<MtkGpt> ReadAsync(
            IMtkDevice device,
            MtkDaxFlashInfo flashInfo,
            CancellationToken cancellationToken
        )
        {
            using (MemoryStream gptStream = new MemoryStream())
            {
                LogService.Information("Reading gpt header");
                await MtkDaxPartitionService.ReadAsync(
                    device,
                    flashInfo,
                    0L,
                    2 * flashInfo.PageSize,
                    gptStream,
                    cancellationToken
                );
                LogService.Information("Parsing gpt header");
                MtkGpt gpt = MtkGptParserService.Parse(gptStream.ToArray(), flashInfo.PageSize);
                LogService.Information("Reading gpt partitions");
                gptStream.SetLength(0L);
                await MtkDaxPartitionService.ReadAsync(
                    device,
                    flashInfo,
                    0L,
                    34 * flashInfo.PageSize,
                    gptStream,
                    cancellationToken
                );
                LogService.Information("Parsing gpt partitions");
                return MtkGptParserService.ParsePartitions(gpt, gptStream.ToArray());
            }
        }

        public static async Task<MtkGpt> ReadAsync(
            Stream inputStream,
            int pageSize,
            CancellationToken cancellationToken
        )
        {
            byte[] data = new byte[34 * pageSize];
            LogService.Information("Parsing gpt header");
            await inputStream.ReadAsync(data, 0, 2 * pageSize, cancellationToken);
            MtkGpt gpt = MtkGptParserService.Parse(data.Take(2 * pageSize).ToArray(), pageSize);
            LogService.Information("Parsing gpt partitions");
            await inputStream.ReadAsync(data, 2 * pageSize, 32 * pageSize, cancellationToken);
            return MtkGptParserService.ParsePartitions(gpt, data);
        }
    }
}
