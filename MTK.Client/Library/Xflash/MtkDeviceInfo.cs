using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace mtkclient.library.xflash
{
    internal class MtkDeviceInfo : IEquatable<MtkDeviceInfo>
    {
        protected virtual Type EqualityContract
        {
            [CompilerGenerated]
            get { return typeof(MtkDeviceInfo); }
        }

        public uint HardwareVersion { get; set; }

        public uint SoftwareVersion { get; set; }

        public bool IsSecure { get; set; }

        public string SecurityLevel { get; set; }

        public MtkChipConfig ChipConfig { get; set; }

        public MtkDeviceInfo(
            uint HardwareVersion,
            uint SoftwareVersion,
            bool IsSecure,
            string SecurityLevel,
            MtkChipConfig ChipConfig
        )
        {
            this.HardwareVersion = HardwareVersion;
            this.SoftwareVersion = SoftwareVersion;
            this.IsSecure = IsSecure;
            this.SecurityLevel = SecurityLevel;
            this.ChipConfig = ChipConfig;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("MtkDeviceInfo");
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
            builder.Append("HardwareVersion = ");
            builder.Append(HardwareVersion.ToString());
            builder.Append(", SoftwareVersion = ");
            builder.Append(SoftwareVersion.ToString());
            builder.Append(", IsSecure = ");
            builder.Append(IsSecure.ToString());
            builder.Append(", SecurityLevel = ");
            builder.Append((object)SecurityLevel);
            builder.Append(", ChipConfig = ");
            builder.Append(ChipConfig);
            return true;
        }

        public static bool operator !=(MtkDeviceInfo left, MtkDeviceInfo right)
        {
            return !(left == right);
        }

        public static bool operator ==(MtkDeviceInfo left, MtkDeviceInfo right)
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
                                EqualityComparer<Type>.Default.GetHashCode(EqualityContract)
                                    * -1521134295
                                + EqualityComparer<uint>.Default.GetHashCode(HardwareVersion)
                            ) * -1521134295
                            + EqualityComparer<uint>.Default.GetHashCode(SoftwareVersion)
                        ) * -1521134295
                        + EqualityComparer<bool>.Default.GetHashCode(IsSecure)
                    ) * -1521134295
                    + EqualityComparer<string>.Default.GetHashCode(SecurityLevel)
                ) * -1521134295
                + EqualityComparer<MtkChipConfig>.Default.GetHashCode(ChipConfig);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MtkDeviceInfo);
        }

        public virtual bool Equals(MtkDeviceInfo other)
        {
            if ((object)this != other)
            {
                if (
                    (object)other != null
                    && EqualityContract == other.EqualityContract
                    && EqualityComparer<uint>.Default.Equals(HardwareVersion, other.HardwareVersion)
                    && EqualityComparer<uint>.Default.Equals(SoftwareVersion, other.SoftwareVersion)
                    && EqualityComparer<bool>.Default.Equals(IsSecure, other.IsSecure)
                    && EqualityComparer<string>.Default.Equals(SecurityLevel, other.SecurityLevel)
                )
                {
                    return EqualityComparer<MtkChipConfig>.Default.Equals(
                        ChipConfig,
                        other.ChipConfig
                    );
                }
                return false;
            }
            return true;
        }

        public virtual MtkDeviceInfo _get()
        {
            return new MtkDeviceInfo(this);
        }

        protected MtkDeviceInfo(MtkDeviceInfo original)
        {
            HardwareVersion = original.HardwareVersion;
            SoftwareVersion = original.SoftwareVersion;
            IsSecure = original.IsSecure;
            SecurityLevel = original.SecurityLevel;
            ChipConfig = original.ChipConfig;
        }

        public void Deconstruct(
            out uint HardwareVersion,
            out uint SoftwareVersion,
            out bool IsSecure,
            out string SecurityLevel,
            out MtkChipConfig ChipConfig
        )
        {
            HardwareVersion = this.HardwareVersion;
            SoftwareVersion = this.SoftwareVersion;
            IsSecure = this.IsSecure;
            SecurityLevel = this.SecurityLevel;
            ChipConfig = this.ChipConfig;
        }
    }
}
