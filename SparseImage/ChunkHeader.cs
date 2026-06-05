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
    public enum ChunkType : ushort
    {
        Raw = 0xCAC1,
        Fill = 0xCAC2,
        DontCare = 0xCAC3,
        CRC = 0xCAC4,
    }

    /// <summary>
    /// Compressed ext4 file system sparse image format is defined by AOSP (Android Open Source Project)
    /// For additional details see https://github.com/android/platform_system_core/blob/master/libsparse/sparse_format.h
    /// </summary>
    public class ChunkHeader
    {
        public const int Length = 12;

        public ChunkType ChunkType;
        public ushort Reserved;
        public uint ChunkSize;
        public uint TotalSize; // header length + entry length

        public ChunkHeader()
        {
        }

        public ChunkHeader(byte[] buffer, int offset)
        {
            ChunkType = (ChunkType)LittleEndianConverter.ToUInt16(buffer, offset + 0);
            Reserved = LittleEndianConverter.ToUInt16(buffer, offset + 2);
            ChunkSize = LittleEndianConverter.ToUInt32(buffer, offset + 4);
            TotalSize = LittleEndianConverter.ToUInt32(buffer, offset + 8);
        }

        public void WriteBytes(byte[] buffer, int offset)
        {
            LittleEndianWriter.WriteUInt16(buffer, offset + 0, (ushort)ChunkType);
            LittleEndianWriter.WriteUInt16(buffer, offset + 2, Reserved);
            LittleEndianWriter.WriteUInt32(buffer, offset + 4, ChunkSize);
            LittleEndianWriter.WriteUInt32(buffer, offset + 8, TotalSize);
        }

        public void WriteBytes(Stream stream)
        {
            byte[] buffer = new byte[Length];
            WriteBytes(buffer, 0);
            ByteWriter.WriteBytes(stream, buffer);
        }

        public static ChunkHeader Read(Stream stream)
        {
            byte[] buffer = new byte[Length];
            stream.Read(buffer, 0, Length);
            return new ChunkHeader(buffer, 0);
        }
    }
}
