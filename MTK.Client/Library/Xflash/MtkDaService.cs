using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace mtkclient.library.xflash
{
    internal class MtkDaService
    {
        static async Task<ushort> ReadUInt16Async(Stream stream)
        {
            byte[] buff = new byte[2];
            await stream.ReadAsync(buff, 0, buff.Length);
            return BitConverter.ToUInt16(buff, 0);
        }

        static async Task<int> ReadInt32Async(Stream stream)
        {
            byte[] buff = new byte[4];
            await stream.ReadAsync(buff, 0, buff.Length);
            return BitConverter.ToInt32(buff, 0);
        }

        static async Task<uint> ReadUInt32Async(Stream stream)
        {
            byte[] buff = new byte[4];
            await stream.ReadAsync(buff, 0, buff.Length);
            return BitConverter.ToUInt32(buff, 0);
        }

        static async Task<MtkDaRegion> ParseRegionAsync(Stream stream)
        {
            return new MtkDaRegion(
                await ReadInt32Async(stream),
                await ReadInt32Async(stream),
                await ReadUInt32Async(stream),
                await ReadUInt32Async(stream),
                await ReadInt32Async(stream)
            );
        }

        static async Task<MtkDaEntry> ParseDaAsync(Stream stream)
        {
            ushort magic = await ReadUInt16Async(stream);
            ushort hardwareCode = await ReadUInt16Async(stream);
            ushort hardwareSubCode = await ReadUInt16Async(stream);
            ushort hardwareVersion = await ReadUInt16Async(stream);
            ushort softwareVersion = await ReadUInt16Async(stream);
            ushort reserved1 = await ReadUInt16Async(stream);
            ushort pageSize = await ReadUInt16Async(stream);
            ushort reserved2 = await ReadUInt16Async(stream);
            ushort entryRegionIndex = await ReadUInt16Async(stream);
            ushort regionCount = await ReadUInt16Async(stream);
            List<MtkDaRegion> regions = new List<MtkDaRegion>();
            ushort i = 0;
            while (i < regionCount)
            {
                List<MtkDaRegion> list = regions;
                list.Add(await ParseRegionAsync(stream));
                ushort num = (ushort)(i + 1);
                i = num;
            }
            return new MtkDaEntry(
                magic,
                hardwareCode,
                hardwareSubCode,
                hardwareVersion,
                softwareVersion,
                reserved1,
                pageSize,
                reserved2,
                entryRegionIndex,
                regions.ToArray()
            );
        }

        public static async Task<MtkDaEntry[]> GetEntriesAsync(Stream daStream)
        {
            daStream.Seek(104L, SeekOrigin.Begin);
            int daCount = await ReadInt32Async(daStream);
            List<MtkDaEntry> result = new List<MtkDaEntry>();
            int i = 0;
            while (i < daCount)
            {
                daStream.Seek(108 + i * 220, SeekOrigin.Begin);
                result.Add(await ParseDaAsync(daStream));
                int num = i + 1;
                i = num;
            }
            return result.ToArray();
        }

        public static async Task<byte[]> GetStage1Async(Stream daStream, MtkDaEntry entry)
        {
            if (entry.Regions.Length >= 3)
            {
                daStream.Seek(entry.Regions[1].Buffer, SeekOrigin.Begin);
                byte[] data = new byte[entry.Regions[1].Length];
                await daStream.ReadAsync(data, 0, data.Length);
                return data;
            }
            throw new ArgumentException("Insufficient DA region count");
        }

        public static async Task<byte[]> GetStage2Async(Stream daStream, MtkDaEntry entry)
        {
            if (entry.Regions.Length < 3)
            {
                throw new ArgumentException("Insufficient DA region count");
            }
            daStream.Seek(entry.Regions[2].Buffer, SeekOrigin.Begin);
            byte[] data = new byte[entry.Regions[2].Length];
            await daStream.ReadAsync(data, 0, data.Length);
            return data;
        }
    }
}
