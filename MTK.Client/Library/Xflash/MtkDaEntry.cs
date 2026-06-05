using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace mtkclient.library.xflash
{
    internal class MtkDaEntry : IEquatable<MtkDaEntry>
    {
        protected virtual Type EqualityContract
        {
            [CompilerGenerated]
            get { return typeof(MtkDaEntry); }
        }

        public ushort Magic { get; set; }

        public ushort HardwareCode { get; set; }

        public ushort HardwareSubCode { get; set; }

        public ushort HardwareVersion { get; set; }

        public ushort SoftwareVersion { get; set; }

        public ushort Reserved1 { get; set; }

        public ushort PageSize { get; set; }

        public ushort Reserved3 { get; set; }

        public ushort EntryRegionIndex { get; set; }

        public MtkDaRegion[] Regions { get; set; }

        public MtkDaEntry(
            ushort Magic,
            ushort HardwareCode,
            ushort HardwareSubCode,
            ushort HardwareVersion,
            ushort SoftwareVersion,
            ushort Reserved1,
            ushort PageSize,
            ushort Reserved3,
            ushort EntryRegionIndex,
            MtkDaRegion[] Regions
        )
        {
            this.Magic = Magic;
            this.HardwareCode = HardwareCode;
            this.HardwareSubCode = HardwareSubCode;
            this.HardwareVersion = HardwareVersion;
            this.SoftwareVersion = SoftwareVersion;
            this.Reserved1 = Reserved1;
            this.PageSize = PageSize;
            this.Reserved3 = Reserved3;
            this.EntryRegionIndex = EntryRegionIndex;
            this.Regions = Regions;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("MtkDaEntry");
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
            builder.Append("Magic = ");
            builder.Append(Magic.ToString());
            builder.Append(", HardwareCode = ");
            builder.Append(HardwareCode.ToString());
            builder.Append(", HardwareSubCode = ");
            builder.Append(HardwareSubCode.ToString());
            builder.Append(", HardwareVersion = ");
            builder.Append(HardwareVersion.ToString());
            builder.Append(", SoftwareVersion = ");
            builder.Append(SoftwareVersion.ToString());
            builder.Append(", Reserved1 = ");
            builder.Append(Reserved1.ToString());
            builder.Append(", PageSize = ");
            builder.Append(PageSize.ToString());
            builder.Append(", Reserved3 = ");
            builder.Append(Reserved3.ToString());
            builder.Append(", EntryRegionIndex = ");
            builder.Append(EntryRegionIndex.ToString());
            builder.Append(", Regions = ");
            builder.Append(Regions);
            return true;
        }

        public static bool operator !=(MtkDaEntry left, MtkDaEntry right)
        {
            return !(left == right);
        }

        public static bool operator ==(MtkDaEntry left, MtkDaEntry right)
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
                                                    EqualityComparer<Type>.Default.GetHashCode(
                                                        EqualityContract
                                                    ) * -1521134295
                                                    + EqualityComparer<ushort>.Default.GetHashCode(
                                                        Magic
                                                    )
                                                ) * -1521134295
                                                + EqualityComparer<ushort>.Default.GetHashCode(
                                                    HardwareCode
                                                )
                                            ) * -1521134295
                                            + EqualityComparer<ushort>.Default.GetHashCode(
                                                HardwareSubCode
                                            )
                                        ) * -1521134295
                                        + EqualityComparer<ushort>.Default.GetHashCode(
                                            HardwareVersion
                                        )
                                    ) * -1521134295
                                    + EqualityComparer<ushort>.Default.GetHashCode(SoftwareVersion)
                                ) * -1521134295
                                + EqualityComparer<ushort>.Default.GetHashCode(Reserved1)
                            ) * -1521134295
                            + EqualityComparer<ushort>.Default.GetHashCode(PageSize)
                        ) * -1521134295
                        + EqualityComparer<ushort>.Default.GetHashCode(Reserved3)
                    ) * -1521134295
                    + EqualityComparer<ushort>.Default.GetHashCode(EntryRegionIndex)
                ) * -1521134295
                + EqualityComparer<MtkDaRegion[]>.Default.GetHashCode(Regions);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MtkDaEntry);
        }

        public virtual bool Equals(MtkDaEntry other)
        {
            if ((object)this != other)
            {
                if (
                    (object)other != null
                    && EqualityContract == other.EqualityContract
                    && EqualityComparer<ushort>.Default.Equals(Magic, other.Magic)
                    && EqualityComparer<ushort>.Default.Equals(HardwareCode, other.HardwareCode)
                    && EqualityComparer<ushort>.Default.Equals(
                        HardwareSubCode,
                        other.HardwareSubCode
                    )
                    && EqualityComparer<ushort>.Default.Equals(
                        HardwareVersion,
                        other.HardwareVersion
                    )
                    && EqualityComparer<ushort>.Default.Equals(
                        SoftwareVersion,
                        other.SoftwareVersion
                    )
                    && EqualityComparer<ushort>.Default.Equals(Reserved1, other.Reserved1)
                    && EqualityComparer<ushort>.Default.Equals(PageSize, other.PageSize)
                    && EqualityComparer<ushort>.Default.Equals(Reserved3, other.Reserved3)
                    && EqualityComparer<ushort>.Default.Equals(
                        EntryRegionIndex,
                        other.EntryRegionIndex
                    )
                )
                {
                    return EqualityComparer<MtkDaRegion[]>.Default.Equals(Regions, other.Regions);
                }
                return false;
            }
            return true;
        }

        public virtual MtkDaEntry _get()
        {
            return new MtkDaEntry(this);
        }

        protected MtkDaEntry(MtkDaEntry original)
        {
            Magic = original.Magic;
            HardwareCode = original.HardwareCode;
            HardwareSubCode = original.HardwareSubCode;
            HardwareVersion = original.HardwareVersion;
            SoftwareVersion = original.SoftwareVersion;
            Reserved1 = original.Reserved1;
            PageSize = original.PageSize;
            Reserved3 = original.Reserved3;
            EntryRegionIndex = original.EntryRegionIndex;
            Regions = original.Regions;
        }

        public void Deconstruct(
            out ushort Magic,
            out ushort HardwareCode,
            out ushort HardwareSubCode,
            out ushort HardwareVersion,
            out ushort SoftwareVersion,
            out ushort Reserved1,
            out ushort PageSize,
            out ushort Reserved3,
            out ushort EntryRegionIndex,
            out MtkDaRegion[] Regions
        )
        {
            Magic = this.Magic;
            HardwareCode = this.HardwareCode;
            HardwareSubCode = this.HardwareSubCode;
            HardwareVersion = this.HardwareVersion;
            SoftwareVersion = this.SoftwareVersion;
            Reserved1 = this.Reserved1;
            PageSize = this.PageSize;
            Reserved3 = this.Reserved3;
            EntryRegionIndex = this.EntryRegionIndex;
            Regions = this.Regions;
        }
    }
}
