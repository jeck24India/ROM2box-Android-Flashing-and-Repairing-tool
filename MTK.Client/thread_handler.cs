using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using clicktoolpro.Shared.Exceptions;

using mtkclient.devicehandler;
using mtkclient.library;
using mtkclient.library.xflash;
using static LogService;

namespace mtkclient.Tasks
{
    class MtkTask
    {
        #region Disable Sleep
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        // Constants for EXECUTION_STATE
        public enum EXECUTION_STATE : uint
        {
            ES_SYSTEM_REQUIRED = 0x1,
            ES_DISPLAY_REQUIRED = 0x2,
            ES_CONTINUOUS = 0x80000000U
        }

        // Method to prevent Windows from entering sleep mode
        public static void PreventSleep()
        {
            SetThreadExecutionState(
                EXECUTION_STATE.ES_CONTINUOUS
                    | EXECUTION_STATE.ES_SYSTEM_REQUIRED
                    | EXECUTION_STATE.ES_DISPLAY_REQUIRED
            );
        }

        // Method to allow Windows to enter sleep mode
        public static void AllowSleep()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
        }
        #endregion

        static MtkDaxUploadResult uploadResult;

        public static MtkGpt gpt;
        public static int multiply;
        public static string storagetype;

        public static async Task InitAsync(CancellationToken cancellationToken)
        {
            string EMI = Main.SharedUI.TxtEMI.Text;
            MtkPreloader preloader;
            LogService.Information("Waiting for MTK Device");
            MtkDeviceWaitResult mtkWaitResult = await MtkDeviceWaiterService.WaitSerialAsync(
                doHandshake: true,
                cancellationToken
            );
            try
            {
                if (mtkWaitResult.IsBootloader)
                {
                    LogService.Information("ok");
                    LogService.Information("Crashing mtk bootloader");
                    await MtkBootloaderCrashService.CrashAsync(
                        mtkWaitResult.Device,
                        cancellationToken
                    );
                    LogService.Information("Disconnecting from mtk serial device");
                    mtkWaitResult.Device.Dispose();
                    mtkWaitResult = null;
                    LogService.Information("ok");
                    LogService.Information("reconnecting");
                    LogService.Information("Waiting for mtk serial device");
                    mtkWaitResult = await MtkDeviceWaiterService.WaitSerialAsync(
                        doHandshake: true,
                        cancellationToken
                    );
                    if (mtkWaitResult.IsBootloader)
                    {
                        LogService.Information("Mtk device is still in bootloader mode");
                        throw new DeviceSecurityNotSupportedException();
                    }
                }
                LogService.Information("Disabling watchdog");
                await MtkWatchdogService.DisableAsync(
                    mtkWaitResult.Device,
                    mtkWaitResult.DeviceInfo.ChipConfig,
                    cancellationToken
                );
                LogService.Information("ok");
                if (mtkWaitResult.DeviceInfo.IsSecure)
                {
                    LogService.Information("Disconnecting from mtk serial device");
                    mtkWaitResult.Device.Dispose();
                    MtkDeviceInfo serialDeviceInfo = mtkWaitResult.DeviceInfo;
                    mtkWaitResult = null;
                    LogService.Information("authorizing");
                    LogService.Information("Waiting for mtk usb device");
                    mtkWaitResult = await MtkDeviceWaiterService.WaitUsbAsync(
                        doHandshake: false,
                        cancellationToken
                    );
                    LogService.Information("Doing mtk auth exploit");
                    await MtkAuthExploitService.ExploitAsync(
                        (IMtkUsbDevice)mtkWaitResult.Device,
                        serialDeviceInfo.ChipConfig,
                        cancellationToken
                    );
                    LogService.Information("Disconnecting from mtk usb device");
                    mtkWaitResult.Device.Dispose();
                    mtkWaitResult = null;
                    LogService.Information("ok");
                    LogService.Information("reconnecting");
                    LogService.Information("Waiting for mtk serial device");
                    mtkWaitResult = await MtkDeviceWaiterService.WaitSerialAsync(
                        doHandshake: true,
                        cancellationToken
                    );
                    if (mtkWaitResult.DeviceInfo.IsSecure)
                    {
                        LogService.Information("Mtk device is still secure");
                        throw new DeviceSecurityNotSupportedException();
                    }
                    LogService.Information("ok");
                }
                if (EMI.Length > 0 && File.Exists(EMI))
                {
                    LogService.Information("Uploading DA");
                    uploadResult = await MtkDaxUploadService.UploadAsync(
                        (MtkSerialDevice)(IMtkSerialDevice)mtkWaitResult.Device,
                        mtkWaitResult.DeviceInfo.ChipConfig,
                        File.ReadAllBytes(EMI),
                        cancellationToken
                    );
                }
                else
                {
                    LogService.Information("Dumping preloader");
                    preloader = await MtkPreloaderService.DumpAsync(
                        mtkWaitResult.Device,
                        mtkWaitResult.DeviceInfo.ChipConfig,
                        cancellationToken
                    );
                    LogService.Information("loading_preloader");

                    LogService.Information("Uploading DA");
                    uploadResult = await MtkDaxUploadService.UploadAsync(
                        (MtkSerialDevice)(IMtkSerialDevice)mtkWaitResult.Device,
                        mtkWaitResult.DeviceInfo.ChipConfig,
                        preloader.Emi,
                        cancellationToken
                    );
                }
            }
            catch
            {
                LogService.Information("Disconnecting from mtk device");
                mtkWaitResult?.Device.Dispose();
                throw;
            }
            finally
            {
                mtkWaitResult.Device.Dispose();
            }
        }

        public static async Task ReadGPT(
            CancellationToken cancelToken = default(CancellationToken),
            bool showlist = true
        )
        {
            try
            {
                gpt = new MtkGpt();
                Console.WriteLine("GPT Len before read gpt : " + gpt.Partitions.Length);
                gpt = await MtkDaxGptService.ReadAsync(
                    uploadResult.Device,
                    uploadResult.FlashInfo,
                    cancelToken
                );
                Console.WriteLine("GPT Len after read gpt : " + gpt.Partitions.Length);
                multiply = 512;
                storagetype = "emmc";
                if (uploadResult.FlashInfo.Type == MtkDaxFlashInfoType.UFS)
                {
                    multiply = 4096;
                    storagetype = "ufs";
                }
                if (showlist)
                {
                    foreach (var sourceItem in gpt.Partitions)
                    {
                        Main.SharedUI.DataViewmtk.Invoke(
                            new Action(
                                () =>
                                    Main.SharedUI.DataViewmtk.Rows.Add(
                                        false,
                                        sourceItem.Name,
                                        sourceItem.FirstLba * multiply,
                                        sourceItem.SectorCount * multiply,
                                        "None",
                                        sourceItem.Id
                                    )
                            )
                        );
                    }
                }
                Main.SharedUI.CkBromReady.Invoke(
                    (Action)(() => Main.SharedUI.CkBromReady.Checked = true)
                );
            }
            catch (Exception exception)
            {
                LogService.Information(
                    exception.ToString(),
                    "Unable to read device gpt. Trying with sgpt"
                );
                LogService.Information("Reading GPT");
                using (MemoryStream sgptStream = new MemoryStream())
                {
                    await MtkDaxPartitionService.ReadAsync(
                        uploadResult.Device,
                        "sgpt",
                        sgptStream,
                        cancelToken
                    );
                    sgptStream.Seek(0L, SeekOrigin.Begin);
                    LogService.Information("Parsing GPT");
                    byte[] buffer = MtkGptRepairService.Fix(
                        sgptStream.ToArray(),
                        uploadResult.FlashInfo.PageSize
                    );
                    using (MemoryStream fixedPgptStream = new MemoryStream(buffer))
                    {
                        MtkGpt gpt;
                        gpt = await MtkDaxGptService.ReadAsync(
                            fixedPgptStream,
                            uploadResult.FlashInfo.PageSize,
                            cancelToken
                        );
                    }
                }
            }

            return;
        }

        public static async Task Read(
            string folder,
            CancellationToken cancelToken = default(CancellationToken)
        )
        {
            try
            {
                foreach (DataGridViewRow item in Main.SharedUI.DataViewmtk.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[0].Value) == true)
                    {
                        Main.Logger.Write(
                            "Reading \t: " + item.Cells[1].Value + " ",
                            Status.SUCCESS,
                            false
                        );
                        await MtkTask.ReadPartition(
                            item.Cells[1].Value.ToString(),
                            folder,
                            Convert.ToInt64(item.Cells[2].Value.ToString()),
                            Convert.ToInt64(item.Cells[3].Value.ToString()),
                            cancelToken
                        );
                        Main.Logger.Write("ok", Status.SUCCESS);
                    }
                }
            }
            finally
            {
                if (Main.SharedUI.CkAutoReboot.Checked)
                {
                    Main.Logger.Write(" ", Status.SUCCESS, true);
                    Main.Logger.Write("Rebooting\t\t:", Status.SUCCESS, false);
                    await Task.Run(() => MtkTask.Reboot(cancelToken));
                    Main.Logger.Write("ok", Status.SUCCESS, true);

                    Main.SharedUI.CkBromReady.Invoke(
                        (Action)(() => Main.SharedUI.CkBromReady.Checked = false)
                    );
                    Main.SharedUI.guna2GradientButton2.Invoke(
                        (Action)(() => Main.SharedUI.guna2GradientButton2.Enabled = false)
                    );
                    Main.SharedUI.guna2GradientButton3.Invoke(
                        (Action)(() => Main.SharedUI.guna2GradientButton3.Enabled = false)
                    );
                    Main.SharedUI.guna2GradientButton1.Invoke(
                        (Action)(() => Main.SharedUI.guna2GradientButton1.Enabled = false)
                    );
                    Main.SharedUI.BtnIdentify.Invoke(
                        (Action)(() => Main.SharedUI.BtnIdentify.Enabled = true)
                    );

                    Main.Logger.Write(" ", Status.SUCCESS, true);
                    Main.Logger.Write("Task Completed...", Status.SUCCESS, true);
                }
                else
                {
                    Main.Logger.Write(" ", Status.SUCCESS, true);
                    Main.Logger.Write("Task Completed...", Status.SUCCESS, true);
                }
            }
            return;
        }

        public static async Task ReadPartition(
            string partition,
            string foldersave,
            long address,
            long size,
            CancellationToken cancelToken = default(CancellationToken)
        )
        {
            string save = foldersave + "//" + partition + ".img";

            if (File.Exists(save))
                File.Delete(save);

            await MtkDaxPartitionService.ReadSaveAsync(
                uploadResult.Device,
                uploadResult.FlashInfo,
                address,
                size,
                save,
                cancelToken
            );
        }

        public static async Task Flash(CancellationToken cancelToken = default(CancellationToken))
        {
            try
            {
                foreach (DataGridViewRow item in Main.SharedUI.DataViewmtk.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[0].Value) == true)
                    {
                        if (File.Exists(item.Cells[4].Value.ToString()))
                        {
                            if (!MtkSparse.CekSparse(item.Cells[4].Value.ToString()))
                            {
                                Main.Logger.Write(
                                    "Flashing \t: " + item.Cells[1].Value + " ",
                                    Status.SUCCESS,
                                    false
                                );

                                await MtkTask.WritePartition(
                                    item.Cells[4].Value.ToString(),
                                    Convert.ToInt64(item.Cells[2].Value),
                                    Convert.ToInt64(item.Cells[3].Value),
                                    cancelToken
                                );

                                Main.Logger.Write("ok", Status.SUCCESS);
                            }
                            else
                            {
                                Main.Logger.Write(
                                    "Flashing \t: " + item.Cells[1].Value + " sparsed ",
                                    Status.SUCCESS,
                                    false
                                );

                                if (!Directory.Exists(Application.StartupPath + "\\tmp"))
                                {
                                    Directory.CreateDirectory(Application.StartupPath + "\\tmp");
                                }

                                string tmp =
                                    Application.StartupPath
                                    + "\\tmp\\unsparse_"
                                    + item.Cells[1].Value
                                    + ".uns";
                                try
                                {
                                    Main.SharedUI.label_writensize.Invoke(
                                        (Action)(
                                            () =>
                                                Main.SharedUI.label_status.Text =
                                                    "Please wait system still unsparsing "
                                                    + item.Cells[1].Value
                                                    + " *IMG *BIN .."
                                        )
                                    );
                                    List<string> sparseList = MtkSparse.GetSparseList(
                                        item.Cells[4].Value.ToString()
                                    );

                                    FileStream output = File.Open(
                                        tmp,
                                        FileMode.Create,
                                        FileAccess.ReadWrite,
                                        FileShare.None
                                    );
                                    MtkSparse.Decompress(sparseList, output);
                                    output.Close();

                                    Main.SharedUI.label_writensize.Invoke(
                                        (Action)(() => Main.SharedUI.label_status.Text = "OK")
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.ToString());
                                }
                                finally
                                {
                                    try
                                    {
                                        await MtkTask.WritePartition(
                                            tmp,
                                            Convert.ToInt64(item.Cells[2].Value),
                                            Convert.ToInt64(item.Cells[3].Value),
                                            cancelToken
                                        );

                                        Main.Logger.Write("ok", Status.SUCCESS);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                if (Main.SharedUI.CkAutoReboot.Checked)
                {
                    Main.Logger.Write(" ", Status.SUCCESS, true);
                    Main.Logger.Write("Rebooting\t\t:", Status.SUCCESS, false);
                    await Task.Run(() => MtkTask.Reboot(cancelToken));
                    Main.Logger.Write("ok", Status.SUCCESS, true);

                    Main.SharedUI.CkBromReady.Invoke(
                        (Action)(() => Main.SharedUI.CkBromReady.Checked = false)
                    );
                    Main.SharedUI.guna2GradientButton2.Invoke(
                        (Action)(() => Main.SharedUI.guna2GradientButton2.Enabled = false)
                    );
                    Main.SharedUI.guna2GradientButton3.Invoke(
                        (Action)(() => Main.SharedUI.guna2GradientButton3.Enabled = false)
                    );
                    Main.SharedUI.guna2GradientButton1.Invoke(
                        (Action)(() => Main.SharedUI.guna2GradientButton1.Enabled = false)
                    );
                    Main.SharedUI.BtnIdentify.Invoke(
                        (Action)(() => Main.SharedUI.BtnIdentify.Enabled = true)
                    );

                    Main.Logger.Write(" ", Status.SUCCESS, true);
                    Main.Logger.Write("Task Completed...", Status.SUCCESS, true);
                }
                else
                {
                    Main.Logger.Write(" ", Status.SUCCESS, true);
                    Main.Logger.Write("Task Completed...", Status.SUCCESS, true);
                }
            }
            return;
        }

        public static async Task WritePartition(
            string files,
            long address,
            long len,
            CancellationToken cancelToken = default(CancellationToken)
        )
        {
            await MtkDaxPartitionService.WriteAsync(
                uploadResult.Device,
                uploadResult.FlashInfo,
                address,
                len,
                files,
                cancelToken
            );
        }

        public static async Task Erase(CancellationToken cancelToken = default(CancellationToken))
        {
            try
            {
                foreach (DataGridViewRow item in Main.SharedUI.DataViewmtk.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[0].Value) == true)
                    {
                        Main.Logger.Write(
                            "Erasing \t: " + item.Cells[1].Value + " ",
                            Status.SUCCESS,
                            false
                        );
                        await MtkTask.FormatPartition(
                            Convert.ToInt64(item.Cells[2].Value),
                            Convert.ToInt64(item.Cells[3].Value),
                            cancelToken
                        );
                        Main.Logger.Write("ok", Status.SUCCESS);
                    }
                }
            }
            finally
            {
                if (Main.SharedUI.CkAutoReboot.Checked)
                {
                    Main.Logger.Write(" ", Status.SUCCESS, true);
                    Main.Logger.Write("Rebooting\t\t:", Status.SUCCESS, false);
                    await Task.Run(() => MtkTask.Reboot(cancelToken));
                    Main.Logger.Write("ok", Status.SUCCESS, true);

                    Main.SharedUI.CkBromReady.Invoke(
                        (Action)(() => Main.SharedUI.CkBromReady.Checked = false)
                    );
                    Main.SharedUI.guna2GradientButton2.Invoke(
                        (Action)(() => Main.SharedUI.guna2GradientButton2.Enabled = false)
                    );
                    Main.SharedUI.guna2GradientButton3.Invoke(
                        (Action)(() => Main.SharedUI.guna2GradientButton3.Enabled = false)
                    );
                    Main.SharedUI.guna2GradientButton1.Invoke(
                        (Action)(() => Main.SharedUI.guna2GradientButton1.Enabled = false)
                    );
                    Main.SharedUI.BtnIdentify.Invoke(
                        (Action)(() => Main.SharedUI.BtnIdentify.Enabled = true)
                    );

                    Main.Logger.Write(" ", Status.SUCCESS, true);
                    Main.Logger.Write("Task Completed...", Status.SUCCESS, true);
                }
                else
                {
                    Main.Logger.Write(" ", Status.SUCCESS, true);
                    Main.Logger.Write("Task Completed...", Status.SUCCESS, true);
                }
            }
            return;
        }

        public static async Task FormatPartition(
            long address,
            long size,
            CancellationToken cancelToken = default(CancellationToken)
        )
        {
            await MtkDaxPartitionService.FormatAsync(
                uploadResult.Device,
                uploadResult.FlashInfo,
                address,
                size,
                cancelToken
            );
        }

        public static async Task Reboot(CancellationToken cancelToken = default(CancellationToken))
        {
            await MtkDaxUploadBootService.RebootAsync(uploadResult.Device, cancelToken);
        }

        public static async Task FormatUserdata(
            CancellationToken cancelToken = default(CancellationToken)
        )
        {
            if (gpt == null)
            {
                await ReadGPT(cancelToken, false);
            }

            if (gpt.Partitions.Length > 0)
            {
                foreach (var sourceItem in gpt.Partitions)
                {
                    if (sourceItem.Name == "userdata")
                    {
                        await FormatPartition(
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                }
                bool reboot = false;
                Main.SharedUI.CkAutoReboot.Invoke(
                    (Action)(() => reboot = Main.SharedUI.CkAutoReboot.Checked)
                );
                if (reboot)
                    await MtkDaxUploadBootService.RebootAsync(uploadResult.Device, cancelToken);
            }
        }

        public static async Task FormatUserdataFRP(
            CancellationToken cancelToken = default(CancellationToken)
        )
        {
            if (gpt == null)
            {
                await ReadGPT(cancelToken, false);
            }

            if (gpt.Partitions.Length > 0)
            {
                foreach (var sourceItem in gpt.Partitions)
                {
                    if (sourceItem.Name == "userdata")
                    {
                        await FormatPartition(
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                    if (sourceItem.Name == "frp")
                    {
                        await FormatPartition(
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                }
                bool reboot = false;
                Main.SharedUI.CkAutoReboot.Invoke(
                    (Action)(() => reboot = Main.SharedUI.CkAutoReboot.Checked)
                );
                if (reboot)
                    await MtkDaxUploadBootService.RebootAsync(uploadResult.Device, cancelToken);
            }
        }

        public static async Task FormatFromRecovery(
            CancellationToken cancelToken = default(CancellationToken)
        )
        {
            if (gpt == null)
            {
                await ReadGPT(cancelToken, false);
            }

            if (gpt.Partitions.Length > 0)
            {
                foreach (var sourceItem in gpt.Partitions)
                {
                    if (sourceItem.Name == "para")
                    {
                        string files = Application.StartupPath + "\\files\\" + storagetype;
                        await WritePartition(
                            files,
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                }
                bool reboot = false;
                Main.SharedUI.CkAutoReboot.Invoke(
                    (Action)(() => reboot = Main.SharedUI.CkAutoReboot.Checked)
                );
                if (reboot)
                    await MtkDaxUploadBootService.RebootAsync(uploadResult.Device, cancelToken);
            }
        }

        public static async Task FormatFromRecoveryFRP(
            CancellationToken cancelToken = default(CancellationToken)
        )
        {
            if (gpt == null)
            {
                await ReadGPT(cancelToken, false);
            }

            if (gpt.Partitions.Length > 0)
            {
                foreach (var sourceItem in gpt.Partitions)
                {
                    if (sourceItem.Name == "para")
                    {
                        string files = Application.StartupPath + "\\files\\" + storagetype;
                        await WritePartition(
                            files,
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }

                    if (sourceItem.Name == "frp")
                    {
                        await FormatPartition(
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                }
                bool reboot = false;
                Main.SharedUI.CkAutoReboot.Invoke(
                    (Action)(() => reboot = Main.SharedUI.CkAutoReboot.Checked)
                );
                if (reboot)
                    await MtkDaxUploadBootService.RebootAsync(uploadResult.Device, cancelToken);
            }
        }

        public static async Task EraseFRPMiCloud(
            CancellationToken cancelToken = default(CancellationToken)
        )
        {
            if (gpt == null)
            {
                await ReadGPT(cancelToken, false);
            }

            if (gpt.Partitions.Length > 0)
            {
                foreach (var sourceItem in gpt.Partitions)
                {
                    if (sourceItem.Name == "frp")
                    {
                        await FormatPartition(
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                    if (sourceItem.Name == "persist")
                    {
                        await FormatPartition(
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                }
                bool reboot = false;
                Main.SharedUI.CkAutoReboot.Invoke(
                    (Action)(() => reboot = Main.SharedUI.CkAutoReboot.Checked)
                );
                if (reboot)
                    await MtkDaxUploadBootService.RebootAsync(uploadResult.Device, cancelToken);
            }
        }

        public static async Task EraseFRP(
            CancellationToken cancelToken = default(CancellationToken)
        )
        {
            if (gpt == null)
            {
                await ReadGPT(cancelToken, false);
            }

            if (gpt.Partitions.Length > 0)
            {
                foreach (var sourceItem in gpt.Partitions)
                {
                    if (sourceItem.Name == "frp")
                    {
                        await FormatPartition(
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                }
                bool reboot = false;
                Main.SharedUI.CkAutoReboot.Invoke(
                    (Action)(() => reboot = Main.SharedUI.CkAutoReboot.Checked)
                );
                if (reboot)
                    await MtkDaxUploadBootService.RebootAsync(uploadResult.Device, cancelToken);
            }
        }

        public static async Task BackupNV(
            string folder,
            CancellationToken cancelToken = default(CancellationToken)
        )
        {
            if (gpt == null)
            {
                await ReadGPT(cancelToken, false);
            }

            if (gpt.Partitions.Length > 0)
            {
                foreach (var sourceItem in gpt.Partitions)
                {
                    if (sourceItem.Name == "nvram")
                    {
                        await ReadPartition(
                            sourceItem.Name,
                            folder,
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                    if (sourceItem.Name == "sec_efs")
                    {
                        await ReadPartition(
                            sourceItem.Name,
                            folder,
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                    if (sourceItem.Name == "nvcfg")
                    {
                        await ReadPartition(
                            sourceItem.Name,
                            folder,
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                    if (sourceItem.Name == "nvdata")
                    {
                        await ReadPartition(
                            sourceItem.Name,
                            folder,
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                    if (sourceItem.Name == "protect1")
                    {
                        await ReadPartition(
                            sourceItem.Name,
                            folder,
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                    if (sourceItem.Name == "protect2")
                    {
                        await ReadPartition(
                            sourceItem.Name,
                            folder,
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                }
                bool reboot = false;
                Main.SharedUI.CkAutoReboot.Invoke(
                    (Action)(() => reboot = Main.SharedUI.CkAutoReboot.Checked)
                );
                if (reboot)
                    await MtkDaxUploadBootService.RebootAsync(uploadResult.Device, cancelToken);
            }
        }

        public static async Task EraseNV(CancellationToken cancelToken = default(CancellationToken))
        {
            if (gpt == null)
            {
                await ReadGPT(cancelToken, false);
            }

            if (gpt.Partitions.Length > 0)
            {
                foreach (var sourceItem in gpt.Partitions)
                {
                    if (sourceItem.Name == "nvram")
                    {
                        await FormatPartition(
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                    if (sourceItem.Name == "sec_efs")
                    {
                        await FormatPartition(
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                    if (sourceItem.Name == "nvcfg")
                    {
                        await FormatPartition(
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                    if (sourceItem.Name == "nvdata")
                    {
                        await FormatPartition(
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                    if (sourceItem.Name == "protect1")
                    {
                        await FormatPartition(
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                    if (sourceItem.Name == "protect2")
                    {
                        await FormatPartition(
                            sourceItem.FirstLba * multiply,
                            sourceItem.SectorCount * multiply,
                            cancelToken
                        );
                    }
                }
                bool reboot = false;
                Main.SharedUI.CkAutoReboot.Invoke(
                    (Action)(() => reboot = Main.SharedUI.CkAutoReboot.Checked)
                );
                if (reboot)
                    await MtkDaxUploadBootService.RebootAsync(uploadResult.Device, cancelToken);
            }
        }
    }
}
