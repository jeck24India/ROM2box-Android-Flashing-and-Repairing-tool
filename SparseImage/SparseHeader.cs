/* Copyright (C) 2014 Tal Aloni <tal.aloni.il@gmail.com>. All rights reserved.
 * 
 * You can redistribute this program and/or modify it under the terms of
 * the GNU Lesser Public License as published by the Free Software Foundation,
 * either version 3 of the License, or (at your option) any later version.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Utilities;

namespace SparseConverter
{
    /// <summary>
    /// Compressed ext4 file system sparse image format is defined by AOSP (Android Open Source Project)
    /// For additional details see https://github.com/android/platform_system_core/blob/master/libsparse/sparse_format.h
    /// </summary>
    public class SparseHeader
    {
        public const uint ValidSignature = 0xed26ff3a;
        public const int Length = 28;
        
        public uint Magic;
        public ushort MajorVersion;
        public ushort MinorVersion;
        public ushort FileHeaderSize;
        public ushort ChunkHeaderSize;
        public uint BlockSize;
        public uint TotalBlocks;
        public uint TotalChunks;
        public uint ImageChecksum;

        public SparseHeader()
        {
            Magic = ValidSignature;
            MajorVersion = 1;
            MinorVersion = 0;
            FileHeaderSize = SparseHeader.Length;
            ChunkHeaderSize = ChunkHeader.Length;
        }

        public SparseHeader(byte[] buffer, int offset)
        {
            Magic = LittleEndianConverter.ToUInt32(buffer, offset + 0);
            MajorVersion = LittleEndianConverter.ToUInt16(buffer, offset + 4);
            MinorVersion = LittleEndianConverter.ToUInt16(buffer, offset + 6);
            FileHeaderSize = LittleEndianConverter.ToUInt16(buffer, offset + 8);
            ChunkHeaderSize = LittleEndianConverter.ToUInt16(buffer, offset + 10);
            BlockSize = LittleEndianConverter.ToUInt32(buffer, offset + 12);
            TotalBlocks = LittleEndianConverter.ToUInt32(buffer, offset + 16);
            TotalChunks = LittleEndianConverter.ToUInt32(buffer, offset + 20);
            ImageChecksum = LittleEndianConverter.ToUInt32(buffer, offset + 24);
        }

        public void WriteBytes(byte[] buffer, int offset)
        {
            LittleEndianWriter.WriteUInt32(buffer, offset + 0, Magic);
            LittleEndianWriter.WriteUInt16(buffer, offset + 4, MajorVersion);
            LittleEndianWriter.WriteUInt16(buffer, offset + 6, MinorVersion);
            LittleEndianWriter.WriteUInt16(buffer, offset + 8, FileHeaderSize);
            LittleEndianWriter.WriteUInt16(buffer, offset + 10, ChunkHeaderSize);
            LittleEndianWriter.WriteUInt32(buffer, offset + 12, BlockSize);
            LittleEndianWriter.WriteUInt32(buffer, offset + 16, TotalBlocks);
            LittleEndianWriter.WriteUInt32(buffer, offset + 20, TotalChunks);
            LittleEndianWriter.WriteUInt32(buffer, offset + 24, ImageChecksum);
        }

        public void WriteBytes(Stream stream)
        {
            byte[] buffer = new byte[Length];
            WriteBytes(buffer, 0);
            ByteWriter.WriteBytes(stream, buffer);
        }

        public static SparseHeader Read(byte[] buffer, int offset)
        {
            uint magic = LittleEndianConverter.ToUInt32(buffer, offset + 0);
            if (magic == ValidSignature)
            {
                return new SparseHeader(buffer, offset);
            }
            return null;
        }

        public static SparseHeader Read(Stream stream)
        {
            byte[] buffer = new byte[Length];
            stream.Read(buffer, 0, Length);
            return Read(buffer, 0);
        }
    }
}
