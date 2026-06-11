using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using clicktoolpro.Shared.Exceptions;
using mtkclient;

using mtkclient.library;
using mtkclient.devicehandler;
using mtkclient.library.xflash;

namespace mtkclient.library
{
    internal class MtkDaxUploadService
    {
        public static async Task<MtkDaxUploadResult> UploadAsync(
            MtkSerialDevice device,
            MtkChipConfig chipConfig,
            byte[] emi,
            CancellationToken cancellationToken
        )
        {
            LogService.Information("Loading DA");

            string daPath = Application.StartupPath + "\\loaders\\MTK_AllInOne_DA_3.3001.09.bin";

            using (Stream daStream = File.OpenRead(daPath))
            {
                daStream.Seek(0L, SeekOrigin.Begin);
                LogService.Information("Getting DA entries");
                MtkDaEntry[] source = await MtkDaService.GetEntriesAsync(daStream);
                daStream.Seek(0L, SeekOrigin.Begin);
                MtkDaEntry daEntry = source
                    .Where((MtkDaEntry x) => chipConfig.DaCode == x.HardwareCode)
                    .FirstOrDefault();
                if (!(daEntry == null))
                {
                    LogService.Information("Calculating DA");
                    byte[] stage1 = await MtkDaService.GetStage1Async(daStream, daEntry);
                    daStream.Seek(0L, SeekOrigin.Begin);
                    byte[] da = await MtkDaService.GetStage2Async(daStream, daEntry);

                    MtkDaxUploadCalculationResult daStages =
                        MtkDaxUploadCalculatorService.Calculate(
                            stage1,
                            da,
                            daEntry.Regions[2].StartAddress,
                            daEntry.Regions[2].SignatureLength
                        );
                    LogService.Information("Sending stage 1 DA");
                    await MtkDaWriteService.WriteAsync(
                        device,
                        daEntry.Regions[1].StartAddress,
                        daEntry.Regions[1].SignatureLength,
                        daStages.Da1,
                        validateUploadStatus: true,
                        cancellationToken
                    );
                    LogService.Information("Jumping DA: 0x{0:X8}", daEntry.Regions[1].StartAddress);
                    await MtkDaWriteService.JumpAsync(
                        device,
                        daEntry.Regions[1].StartAddress,
                        cancellationToken
                    );
                    LogService.Information("Syncing DA");
                    await MtkDaxUploadSyncService.SyncAsync(device, cancellationToken);
                    LogService.Information("Getting expire date");
                    string propertyValue = await MtkDaxDeviceControlSetupService.GetExpireDateAsync(
                        device,
                        cancellationToken
                    );
                    LogService.Information("Expire date: {0}", propertyValue);
                    LogService.Information("Setting reset key: 0x68");
                    await MtkDaxDeviceControlSetupService.SetResetKeyAsync(
                        device,
                        104u,
                        cancellationToken
                    );
                    LogService.Information("Setting checksum level: 0");
                    await MtkDaxDeviceControlSetupService.SetChecksumLevelAsync(
                        device,
                        0u,
                        cancellationToken
                    );
                    LogService.Information("Getting connection agent");
                    string text = await MtkDaxDeviceControlSetupService.GetConnectionAgentAsync(
                        device,
                        cancellationToken
                    );
                    LogService.Information("Connection agent: {0}", text);
                    if (text == "brom")
                    {
                        LogService.Information("Uploading EMI");
                        await MtkDaxUploadEmiService.UploadEmiAsync(device, emi, cancellationToken);
                    }
                    else if (text != "preloader")
                    {
                        throw new Exception("Invalid connection agent: " + text);
                    }
                    LogService.Information(
                        "Booting to stage 2 address: 0x{0:X8}",
                        daEntry.Regions[2].StartAddress
                    );
                    await MtkDaxUploadBootService.BootToAsync(
                        device,
                        daEntry.Regions[2].StartAddress,
                        daStages.Da2,
                        cancellationToken
                    );
                    LogService.Information("Getting usb speed");
                    string text2 = await MtkDaxDeviceControlSetupService.GetUsbSpeedAsync(
                        device,
                        cancellationToken
                    );
                    LogService.Information("Usb speed: {0}", text2);
                    bool switched = false;
                    //if (text2 == "full-speed")
                    //{
                    LogService.Information("Switching usb speed");
                    await MtkDaxUploadSetupService.SwitchUsbSpeedAsync(device, cancellationToken);
                    LogService.Information("Disconnecting from device");
                    device.Dispose();
                    LogService.Information("Waiting for 3 seconds");
                    await Task.Delay(TimeSpan.FromSeconds(3.0));
                    LogService.Information("Waiting for mtk serial device");
                    device = (MtkSerialDevice)
                        (IMtkSerialDevice)
                            (
                                await MtkDeviceWaiterService.WaitSerialAsync(
                                    doHandshake: false,
                                    cancellationToken
                                )
                            ).Device;

                    switched = true;
                    //}
                    try
                    {
                        LogService.Information("Getting storage info");
                        MtkDaxFlashInfo flashInfo2 =
                            await MtkDaxDeviceStorageInfoService.GetStorageInfoAsync(
                                device,
                                cancellationToken
                            );
                        LogService.Information("Booting to address 0x68000000 with DA extension");
                        await MtkDaxUploadBootService.BootToAsync(
                            device,
                            1744830464L,
                            daStages.Extension,
                            cancellationToken
                        );
                        LogService.Information("Sending custom ack");
                        await MtkDaxDeviceControlSetupService.SendCustomAckAsync(
                            device,
                            cancellationToken
                        );
                        LogService.Information("Getting packet length");
                        PartitionPacketLength partitionPacketLength =
                            await MtkDaxPartitionPacketLengthService.GetAsync(
                                device,
                                cancellationToken
                            );
                        MtkDaxFlashInfo mtkDaxFlashInfo = flashInfo2._get();
                        mtkDaxFlashInfo.WriteBufferSize = partitionPacketLength.WriteLen;
                        mtkDaxFlashInfo.ReadBufferSize = partitionPacketLength.ReadLen;
                        flashInfo2 = mtkDaxFlashInfo;
                        Main.SharedUI.CkBromReady.Invoke(
                            (Action)(() => Main.SharedUI.CkBromReady.Checked = true)
                        );
                        return new MtkDaxUploadResult(device, flashInfo2);
                    }
                    catch
                    {
                        if (switched)
                        {
                            LogService.Information("Disconnecting from switched serial device");
                            device.Dispose();
                        }
                        throw;
                    }
                }
                LogService.Information("DA code not found: 0x{0:X8}", chipConfig.DaCode);
                throw new DeviceSecurityNotSupportedException();
            }
        }
    }
}
