using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace mtkclient.library
{
    internal class MtkDaxPartitionService
    {
        public static async Task SendCommandAsync(
            IMtkDevice device,
            MtkDaxFlashInfo flashInfo,
            uint command,
            int partitionType,
            long address,
            long size,
            CancellationToken cancellationToken
        )
        {
            await MtkDaxService.SendAsync(device, command, cancellationToken);
            uint num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
            if (num == 0)
            {
                using (MemoryStream paramStream = new MemoryStream())
                {
                    paramStream.Write(BitConverter.GetBytes((int)flashInfo.Type));
                    paramStream.Write(BitConverter.GetBytes(partitionType));
                    paramStream.Write(BitConverter.GetBytes(address));
                    paramStream.Write(BitConverter.GetBytes(size));
                    paramStream.Write(new byte[32]);
                    await MtkDaxService.SendAsync(device, paramStream.ToArray(), cancellationToken);
                    num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
                    if (num != 0)
                    {
                        throw new Exception($"Invalid DAX flash command param status: 0x{num:X8}");
                    }
                    return;
                }
            }
            throw new Exception($"Invalid DAX flash command status: 0x{num:X8}");
        }

        public static async Task ReadAsync(
            IMtkDevice device,
            MtkDaxFlashInfo flashInfo,
            long address,
            long size,
            Stream outputStream,
            CancellationToken cancellationToken
        )
        {
            Main.SharedUI.label_totalsize.Invoke(
                (Action)(() => Main.SharedUI.label_totalsize.Text = Extension.GetFileSize(size))
            );

            await SendCommandAsync(
                device,
                flashInfo,
                65541u,
                (flashInfo.Type == MtkDaxFlashInfoType.UFS) ? 3 : 8,
                address,
                size,
                cancellationToken
            );
            uint num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
            if (num == 0)
            {
                var Stopwatch = new Stopwatch();
                Stopwatch.Start();

                long totalRead = 0L;
                while (totalRead < size)
                {
                    byte[] readBuff = await MtkDaxService.ReadAsync(device, cancellationToken);
                    await outputStream.WriteAsync(readBuff, 0, readBuff.Length);
                    totalRead += readBuff.Length;

                    Main.SharedUI.label_writensize.Invoke(
                        (Action)(
                            () =>
                                Main.SharedUI.label_writensize.Text = Extension.GetFileSize(
                                    totalRead
                                )
                        )
                    );

                    TimeSpan elapsed = Stopwatch.Elapsed;
                    double speed = totalRead / elapsed.TotalSeconds;
                    Main.SharedUI.label_transferrate.Invoke(
                        (Action)(
                            () =>
                                Main.SharedUI.label_transferrate.Text =
                                    Extension.GetFileSize(Convert.ToInt64(speed)) + " /s"
                        )
                    );

                    Main.ProcessBar(totalRead, size);
                    uint num2 = await MtkDaxService.ReadAckAsync(device, cancellationToken);
                    if (num2 == 0)
                    {
                        continue;
                    }

                    Stopwatch.Stop();
                    break;
                }
                return;
            }
            throw new Exception($"Invalid partition read command status: 0x{num:X8}");
        }

        public static async Task ReadSaveAsync(
            IMtkDevice device,
            MtkDaxFlashInfo flashInfo,
            long address,
            long size,
            string save,
            CancellationToken cancellationToken
        )
        {
            Main.SharedUI.label_totalsize.Invoke(
                (Action)(() => Main.SharedUI.label_totalsize.Text = Extension.GetFileSize(size))
            );

            await SendCommandAsync(
                device,
                flashInfo,
                65541u,
                (flashInfo.Type == MtkDaxFlashInfoType.UFS) ? 3 : 8,
                address,
                size,
                cancellationToken
            );

            FileStream fs = new FileStream(save, FileMode.Append, FileAccess.Write);
            using (fs)
            {
                uint num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
                if (num == 0)
                {
                    var Stopwatch = new Stopwatch();
                    Stopwatch.Start();

                    long totalRead = 0L;
                    while (totalRead < size)
                    {
                        byte[] readBuff = await MtkDaxService.ReadAsync(device, cancellationToken);
                        await fs.WriteAsync(readBuff, 0, readBuff.Length);
                        totalRead += readBuff.Length;

                        Main.SharedUI.label_writensize.Invoke(
                            (Action)(
                                () =>
                                    Main.SharedUI.label_writensize.Text = Extension.GetFileSize(
                                        totalRead
                                    )
                            )
                        );

                        TimeSpan elapsed = Stopwatch.Elapsed;
                        double speed = totalRead / elapsed.TotalSeconds;
                        Main.SharedUI.label_transferrate.Invoke(
                            (Action)(
                                () =>
                                    Main.SharedUI.label_transferrate.Text =
                                        Extension.GetFileSize(Convert.ToInt64(speed)) + " /s"
                            )
                        );

                        Main.ProcessBar(totalRead, size);
                        uint num2 = await MtkDaxService.ReadAckAsync(device, cancellationToken);
                        if (num2 == 0)
                        {
                            continue;
                        }

                        Stopwatch.Stop();
                        break;
                    }
                    fs.Close();
                    return;
                }
                throw new Exception($"Invalid partition read command status: 0x{num:X8}");
            }
        }

        public static async Task ReadAsync(
            IMtkDevice device,
            string partitionName,
            Stream outputStream,
            CancellationToken cancellationToken
        )
        {
            await MtkDaxDeviceControlService.SendDevCtrlNoReadAsync(
                device,
                524289u,
                cancellationToken
            );
            uint num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
            if (num == 0)
            {
                await MtkDaxService.SendAsync(device, 65538u, cancellationToken);
                num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
                if (num == 0)
                {
                    await MtkDaxService.SendAsync(
                        device,
                        Encoding.ASCII.GetBytes(partitionName),
                        cancellationToken
                    );
                    num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
                    if (num == 0)
                    {
                        byte[] partitionSizeBuff = await MtkDaxService.ReadAsync(
                            device,
                            cancellationToken
                        );
                        if (partitionSizeBuff.Length >= 8)
                        {
                            num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
                            if (num != 0)
                            {
                                throw new Exception($"Invalid partition size status: 0x{num:X8}");
                            }

                            long partitionSize = BitConverter.ToInt64(partitionSizeBuff, 0);
                            Main.SharedUI.label_totalsize.Invoke(
                                (Action)(
                                    () =>
                                        Main.SharedUI.label_totalsize.Text = Extension.GetFileSize(
                                            partitionSize
                                        )
                                )
                            );

                            var Stopwatch = new Stopwatch();
                            Stopwatch.Start();

                            long totalRead = 0L;
                            while (totalRead < partitionSize)
                            {
                                cancellationToken.ThrowIfCancellationRequested();
                                byte[] partitionBuff = await MtkDaxService.ReadAsync(
                                    device,
                                    cancellationToken
                                );
                                await outputStream.WriteAsync(
                                    partitionBuff,
                                    0,
                                    partitionBuff.Length
                                );
                                totalRead += partitionBuff.Length;

                                Main.SharedUI.label_writensize.Invoke(
                                    (Action)(
                                        () =>
                                            Main.SharedUI.label_writensize.Text =
                                                Extension.GetFileSize(totalRead)
                                    )
                                );

                                TimeSpan elapsed = Stopwatch.Elapsed;
                                double speed = totalRead / elapsed.TotalSeconds;
                                Main.SharedUI.label_transferrate.Invoke(
                                    (Action)(
                                        () =>
                                            Main.SharedUI.label_transferrate.Text =
                                                Extension.GetFileSize(Convert.ToInt64(speed))
                                                + " /s"
                                    )
                                );

                                Main.ProcessBar(totalRead, partitionSize);
                            }
                            Stopwatch.Stop();
                            await MtkDaxService.SendAsync(device, 0u, cancellationToken);
                            LogService.Information("Reading complete status response");
                            num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
                            if (num != 0)
                            {
                                throw new Exception(
                                    $"Invalid complete status response: 0x{num:X8}"
                                );
                            }
                            return;
                        }
                        throw new Exception(
                            "Invalid partition size buffer length: " + partitionSizeBuff.Length
                        );
                    }
                    throw new Exception($"Invalid partition name param status: 0x{num:X8}");
                }
                throw new Exception($"Invalid DAX upload command status: 0x{num:X8}");
            }
            throw new Exception($"Invalid START_DL_INFO status: 0x{num:X8}");
        }

        public static async Task FormatAsync(
            IMtkDevice device,
            MtkDaxFlashInfo flashInfo,
            long address,
            long size,
            CancellationToken cancellationToken
        )
        {
            await SendCommandAsync(
                device,
                flashInfo,
                65539u,
                (flashInfo.Type == MtkDaxFlashInfoType.UFS) ? 3 : 8,
                address,
                size,
                cancellationToken
            );
            uint num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
            while (true)
            {
                switch (num)
                {
                    case 1074003972u:
                        cancellationToken.ThrowIfCancellationRequested();
                        num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
                        await Task.Delay(TimeSpan.FromMilliseconds(num), cancellationToken);
                        num = await MtkDaxService.ReadAckAsync(device, cancellationToken);
                        break;
                    default:
                        throw new Exception(
                            $"Invalid format partition complete status: 0x{num:X8}"
                        );
                    case 0u:
                    case 1074003973u:
                        return;
                }
            }
        }

        public static async Task WriteAsync(
            IMtkDevice device,
            MtkDaxFlashInfo flashInfo,
            int lu,
            long address,
            long len,
            string files,
            CancellationToken cancellationToken
        )
        {
            if (flashInfo.Type != MtkDaxFlashInfoType.UFS && lu != 8)
            {
                throw new ArgumentException("Invalid flash type: " + lu);
            }

            Stream inputStream = File.OpenRead(files);
            inputStream.Seek(0L, SeekOrigin.Begin);

            try
            {
                await SendCommandAsync(
                    device,
                    flashInfo,
                    65540u,
                    lu,
                    address,
                    inputStream.Length,
                    cancellationToken
                );
                long sent = 0L;

                byte[] payloadBuff;
                if (inputStream.Length < flashInfo.WriteBufferSize)
                {
                    payloadBuff = new byte[inputStream.Length];
                }
                else
                {
                    payloadBuff = new byte[flashInfo.WriteBufferSize];
                }

                Main.SharedUI.label_totalsize.Invoke(
                    (Action)(
                        () =>
                            Main.SharedUI.label_totalsize.Text = Extension.GetFileSize(
                                inputStream.Length
                            )
                    )
                );

                var Stopwatch = new Stopwatch();
                Stopwatch.Start();

                uint num;
                while (true)
                {
                    if (sent < inputStream.Length)
                    {
                        int count = (int)Math.Min(payloadBuff.Length, inputStream.Length - sent);
                        int read = await inputStream.ReadAsync(
                            payloadBuff,
                            0,
                            count,
                            cancellationToken
                        );
                        if (read != 0)
                        {
                            byte[] payload = payloadBuff.Take(read).ToArray();
                            int checksum = MtkDaxPartitionChecksumService.Calculate(payload);
                            await MtkDaxService.SendAsync(device, 0u, cancellationToken);
                            await MtkDaxService.SendAsync(
                                device,
                                (uint)checksum,
                                cancellationToken
                            );
                            await MtkDaxService.SendAsync(
                                device,
                                payload,
                                payload.Length,
                                cancellationToken
                            );
                            num = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
                            if (num != 0)
                            {
                                break;
                            }
                            sent += read;

                            Main.SharedUI.label_writensize.Invoke(
                                (Action)(
                                    () =>
                                        Main.SharedUI.label_writensize.Text = Extension.GetFileSize(
                                            sent
                                        )
                                )
                            );

                            TimeSpan elapsed = Stopwatch.Elapsed;
                            double speed = sent / elapsed.TotalSeconds;
                            Main.SharedUI.label_transferrate.Invoke(
                                (Action)(
                                    () =>
                                        Main.SharedUI.label_transferrate.Text =
                                            Extension.GetFileSize(Convert.ToInt64(speed)) + " /s"
                                )
                            );

                            Main.ProcessBar(sent, inputStream.Length);
                            continue;
                        }
                        throw new ArgumentException("Unable to read input stream");
                    }
                    Stopwatch.Stop();
                    uint num2 = await MtkDaxService.ReadStatusAsync(device, cancellationToken);
                    if (num2 == 0)
                    {
                        await MtkDaxDeviceControlService.SendDevCtrlAsync(
                            device,
                            8388613u,
                            cancellationToken
                        );
                        return;
                    }
                    throw new Exception($"Invalid done write partition status: 0x{num2:X8}");
                }
                throw new Exception($"Invalid write partition status: 0x{num:X8}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                inputStream.Close();

                if (files.Contains(".uns"))
                    File.Delete(files);
            }
        }

        public static Task WriteAsync(
            IMtkDevice device,
            MtkDaxFlashInfo flashInfo,
            long address,
            long len,
            string files,
            CancellationToken cancellationToken
        )
        {
            return WriteAsync(
                device,
                flashInfo,
                (flashInfo.Type == MtkDaxFlashInfoType.UFS) ? 3 : 8,
                address,
                len,
                files,
                cancellationToken
            );
        }
    }
}
