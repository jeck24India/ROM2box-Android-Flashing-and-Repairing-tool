using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace mtkclient.library.xflash
{
    internal class MtkGpt : IEquatable<MtkGpt>
    {
        protected virtual Type EqualityContract
        {
            [CompilerGenerated]
            get { return typeof(MtkGpt); }
        }

        public string Signature { get; set; }

        public int Revision { get; set; }

        public int HeaderSize { get; set; }

        public int Crc32 { get; set; }

        public int Reserved { get; set; }

        public long CurrentLba { get; set; }

        public long BackupLba { get; set; }

        public long FirstUsableLba { get; set; }

        public long LastUsableLba { get; set; }

        public Guid Guid { get; set; }

        public long PartitionEntryStartLba { get; set; }

        public int PartitionEntriesCount { get; set; }

        public int PartitionEntrySize { get; set; }

        public int SectorSize { get; set; }

        public MtkGptPartition[] Partitions { get; set; }

        public MtkGpt()
        {
            Signature = "";
            Partitions = new MtkGptPartition[0];
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("MtkGpt");
            stringBuilder.Append(" { ");
            if (PrintMembers(stringBuilder))
            {
                stringBuilder.Append(' ');
            }
            stringBuilder.Append('}');
            return stringBuilder.ToString();
        }

        protected virtual bool PrintMembers(StringBuilder builder)
        {
            RuntimeHelpers.EnsureSufficientExecutionStack();
            builder.Append("Signature = ");
            builder.Append((object)Signature);
            builder.Append(", Revision = ");
            builder.Append(Revision.ToString());
            builder.Append(", HeaderSize = ");
            builder.Append(HeaderSize.ToString());
            builder.Append(", Crc32 = ");
            builder.Append(Crc32.ToString());
            builder.Append(", Reserved = ");
            builder.Append(Reserved.ToString());
            builder.Append(", CurrentLba = ");
            builder.Append(CurrentLba.ToString());
            builder.Append(", BackupLba = ");
            builder.Append(BackupLba.ToString());
            builder.Append(", FirstUsableLba = ");
            builder.Append(FirstUsableLba.ToString());
            builder.Append(", LastUsableLba = ");
            builder.Append(LastUsableLba.ToString());
            builder.Append(", Guid = ");
            builder.Append(Guid.ToString());
            builder.Append(", PartitionEntryStartLba = ");
            builder.Append(PartitionEntryStartLba.ToString());
            builder.Append(", PartitionEntriesCount = ");
            builder.Append(PartitionEntriesCount.ToString());
            builder.Append(", PartitionEntrySize = ");
            builder.Append(PartitionEntrySize.ToString());
            builder.Append(", SectorSize = ");
            builder.Append(SectorSize.ToString());
            builder.Append(", Partitions = ");
            builder.Append(Partitions);
            return true;
        }

        public static bool operator !=(MtkGpt left, MtkGpt right)
        {
            return !(left == right);
        }

        public static bool operator ==(MtkGpt left, MtkGpt right)
        {
            if ((object)left != right)
            {
                return left?.Equals(right) ?? false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return (
                    (
                        (
                            (
                                (
                                    (
                                        (
                                            (
                                                (
                                                    (
                                                        (
                                                            (
                                                                (
                                                                    (
                                                                        EqualityComparer<Type>.Default.GetHashCode(
                                                                            EqualityContract
                                                                        ) * -1521134295
                                                                        + EqualityComparer<string>.Default.GetHashCode(
                                                                            Signature
                                                                        )
                                                                    ) * -1521134295
                                                                    + EqualityComparer<int>.Default.GetHashCode(
                                                                        Revision
                                                                    )
                                                                ) * -1521134295
                                                                + EqualityComparer<int>.Default.GetHashCode(
                                                                    HeaderSize
                                                                )
                                                            ) * -1521134295
                                                            + EqualityComparer<int>.Default.GetHashCode(
                                                                Crc32
                                                            )
                                                        ) * -1521134295
                                                        + EqualityComparer<int>.Default.GetHashCode(
                                                            Reserved
                                                        )
                                                    ) * -1521134295
                                                    + EqualityComparer<long>.Default.GetHashCode(
                                                        CurrentLba
                                                    )
                                                ) * -1521134295
                                                + EqualityComparer<long>.Default.GetHashCode(
                                                    BackupLba
                                                )
                                            ) * -1521134295
                                            + EqualityComparer<long>.Default.GetHashCode(
                                                FirstUsableLba
                                            )
                                        ) * -1521134295
                                        + EqualityComparer<long>.Default.GetHashCode(LastUsableLba)
                                    ) * -1521134295
                                    + EqualityComparer<Guid>.Default.GetHashCode(Guid)
                                ) * -1521134295
                                + EqualityComparer<long>.Default.GetHashCode(PartitionEntryStartLba)
                            ) * -1521134295
                            + EqualityComparer<int>.Default.GetHashCode(PartitionEntriesCount)
                        ) * -1521134295
                        + EqualityComparer<int>.Default.GetHashCode(PartitionEntrySize)
                    ) * -1521134295
                    + EqualityComparer<int>.Default.GetHashCode(SectorSize)
                ) * -1521134295
                + EqualityComparer<MtkGptPartition[]>.Default.GetHashCode(Partitions);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MtkGpt);
        }

        public virtual bool Equals(MtkGpt other)
        {
            if ((object)this != other)
            {
                if (
                    (object)other != null
                    && EqualityContract == other.EqualityContract
                    && EqualityComparer<string>.Default.Equals(Signature, other.Signature)
                    && EqualityComparer<int>.Default.Equals(Revision, other.Revision)
                    && EqualityComparer<int>.Default.Equals(HeaderSize, other.HeaderSize)
                    && EqualityComparer<int>.Default.Equals(Crc32, other.Crc32)
                    && EqualityComparer<int>.Default.Equals(Reserved, other.Reserved)
                    && EqualityComparer<long>.Default.Equals(CurrentLba, other.CurrentLba)
                    && EqualityComparer<long>.Default.Equals(BackupLba, other.BackupLba)
                    && EqualityComparer<long>.Default.Equals(FirstUsableLba, other.FirstUsableLba)
                    && EqualityComparer<long>.Default.Equals(LastUsableLba, other.LastUsableLba)
                    && EqualityComparer<Guid>.Default.Equals(Guid, other.Guid)
                    && EqualityComparer<long>.Default.Equals(
                        PartitionEntryStartLba,
                        other.PartitionEntryStartLba
                    )
                    && EqualityComparer<int>.Default.Equals(
                        PartitionEntriesCount,
                        other.PartitionEntriesCount
                    )
                    && EqualityComparer<int>.Default.Equals(
                        PartitionEntrySize,
                        other.PartitionEntrySize
                    )
                    && EqualityComparer<int>.Default.Equals(SectorSize, other.SectorSize)
                )
                {
                    return EqualityComparer<MtkGptPartition[]>.Default.Equals(
                        Partitions,
                        other.Partitions
                    );
                }
                return false;
            }
            return true;
        }

        public virtual MtkGpt _get()
        {
            return new MtkGpt(this);
        }

        protected MtkGpt(MtkGpt original)
        {
            Signature = original.Signature;
            Revision = original.Revision;
            HeaderSize = original.HeaderSize;
            Crc32 = original.Crc32;
            Reserved = original.Reserved;
            CurrentLba = original.CurrentLba;
            BackupLba = original.BackupLba;
            FirstUsableLba = original.FirstUsableLba;
            LastUsableLba = original.LastUsableLba;
            Guid = original.Guid;
            PartitionEntryStartLba = original.PartitionEntryStartLba;
            PartitionEntriesCount = original.PartitionEntriesCount;
            PartitionEntrySize = original.PartitionEntrySize;
            SectorSize = original.SectorSize;
            Partitions = original.Partitions;
        }
    }
}
