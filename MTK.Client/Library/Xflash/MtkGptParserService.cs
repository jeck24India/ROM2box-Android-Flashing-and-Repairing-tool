using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace mtkclient.library.xflash
{
    internal class MtkGptParserService
    {
        static int Read4Byte(MemoryStream ms)
        {
            byte[] array = new byte[4];
            ms.Read(array, 0, 4);
            return BitConverter.ToInt32(array, 0);
        }

        static long Read8Byte(MemoryStream ms)
        {
            byte[] array = new byte[8];
            ms.Read(array, 0, 8);
            return BitConverter.ToInt64(array, 0);
        }

        public static MtkGpt Parse(byte[] headerData, int sectorSize)
        {
            using (MemoryStream memoryStream = new MemoryStream(headerData))
            {
                memoryStream.Seek(sectorSize, SeekOrigin.Begin);
                byte[] array = new byte[8];
                memoryStream.Read(array, 0, array.Length);
                string @string = Encoding.ASCII.GetString(array);
                if (!(@string != "EFI PART"))
                {
                    int num = Read4Byte(memoryStream);
                    if (num != 65536)
                    {
                        throw new Exception($"Invalid gpt revision: 0x{num:X8}");
                    }
                    int headerSize = Read4Byte(memoryStream);
                    int crc = Read4Byte(memoryStream);
                    int reserved = Read4Byte(memoryStream);
                    long currentLba = Read8Byte(memoryStream);
                    long backupLba = Read8Byte(memoryStream);
                    long firstUsableLba = Read8Byte(memoryStream);
                    long lastUsableLba = Read8Byte(memoryStream);
                    byte[] array2 = new byte[16];
                    memoryStream.Read(array2, 0, array2.Length);
                    Guid guid = new Guid(array2);
                    long partitionEntryStartLba = Read8Byte(memoryStream);
                    int partitionEntriesCount = Read4Byte(memoryStream);
                    int partitionEntrySize = Read4Byte(memoryStream);
                    return new MtkGpt
                    {
                        Signature = @string,
                        Revision = num,
                        HeaderSize = headerSize,
                        Crc32 = crc,
                        Reserved = reserved,
                        CurrentLba = currentLba,
                        BackupLba = backupLba,
                        FirstUsableLba = firstUsableLba,
                        LastUsableLba = lastUsableLba,
                        Guid = guid,
                        PartitionEntryStartLba = partitionEntryStartLba,
                        PartitionEntriesCount = partitionEntriesCount,
                        PartitionEntrySize = partitionEntrySize,
                        SectorSize = sectorSize
                    };
                }
                throw new Exception("Invalid gpt signature: " + @string);
            }
        }

        public static MtkGpt ParsePartitions(MtkGpt gpt, byte[] partitionsData)
        {
            List<MtkGptPartition> list = new List<MtkGptPartition>();
            using (MemoryStream memoryStream = new MemoryStream(partitionsData))
            {
                memoryStream.Seek(gpt.PartitionEntryStartLba * gpt.SectorSize, SeekOrigin.Begin);
                for (int i = 0; i < gpt.PartitionEntriesCount; i++)
                {
                    long position = memoryStream.Position;
                    int type = Read4Byte(memoryStream);
                    memoryStream.Read(new byte[12], 0, 12);
                    byte[] array = new byte[16];
                    memoryStream.Read(array, 0, array.Length);
                    Guid id = new Guid(array);
                    long firstLba = Read8Byte(memoryStream);
                    long lastLba = Read8Byte(memoryStream);
                    long flags = Read8Byte(memoryStream);
                    byte[] array2 = new byte[72];
                    memoryStream.Read(array2, 0, array2.Length);
                    string text = Encoding.Unicode.GetString(array2).TrimEnd(default(char));
                    if (text != "")
                    {
                        list.Add(
                            new MtkGptPartition
                            {
                                Type = type,
                                Id = id,
                                FirstLba = firstLba,
                                LastLba = lastLba,
                                Flags = flags,
                                Name = text
                            }
                        );
                    }
                    long num = memoryStream.Position - position;
                    if (num < gpt.PartitionEntrySize)
                    {
                        memoryStream.Seek(gpt.PartitionEntrySize - num, SeekOrigin.Current);
                    }
                }
                MtkGpt mtkGpt = gpt._get();
                mtkGpt.Partitions = list.ToArray();
                return mtkGpt;
            }
        }
    }
}
