using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace mtkclient.library.xflash
{
    internal class MtkDeviceWaitResult : IEquatable<MtkDeviceWaitResult>
    {
        protected virtual Type EqualityContract
        {
            [CompilerGenerated]
            get { return typeof(MtkDeviceWaitResult); }
        }

        public IMtkDevice Device { get; set; }

        public bool IsBootloader { get; set; }

        public MtkDeviceInfo DeviceInfo { get; set; }

        public MtkDeviceWaitResult(IMtkDevice Device, bool IsBootloader, MtkDeviceInfo DeviceInfo)
        {
            this.Device = Device;
            this.IsBootloader = IsBootloader;
            this.DeviceInfo = DeviceInfo;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("MtkDeviceWaitResult");
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
            builder.Append("Device = ");
            builder.Append(Device);
            builder.Append(", IsBootloader = ");
            builder.Append(IsBootloader.ToString());
            builder.Append(", DeviceInfo = ");
            builder.Append(DeviceInfo);
            return true;
        }

        public static bool operator !=(MtkDeviceWaitResult left, MtkDeviceWaitResult right)
        {
            return !(left == right);
        }

        public static bool operator ==(MtkDeviceWaitResult left, MtkDeviceWaitResult right)
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
                        EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295
                        + EqualityComparer<IMtkDevice>.Default.GetHashCode(Device)
                    ) * -1521134295
                    + EqualityComparer<bool>.Default.GetHashCode(IsBootloader)
                ) * -1521134295
                + EqualityComparer<MtkDeviceInfo>.Default.GetHashCode(DeviceInfo);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MtkDeviceWaitResult);
        }

        public virtual bool Equals(MtkDeviceWaitResult other)
        {
            if ((object)this != other)
            {
                if (
                    (object)other != null
                    && EqualityContract == other.EqualityContract
                    && EqualityComparer<IMtkDevice>.Default.Equals(Device, other.Device)
                    && EqualityComparer<bool>.Default.Equals(IsBootloader, other.IsBootloader)
                )
                {
                    return EqualityComparer<MtkDeviceInfo>.Default.Equals(
                        DeviceInfo,
                        other.DeviceInfo
                    );
                }
                return false;
            }
            return true;
        }

        public virtual MtkDeviceWaitResult _get()
        {
            return new MtkDeviceWaitResult(this);
        }

        protected MtkDeviceWaitResult(MtkDeviceWaitResult original)
        {
            Device = original.Device;
            IsBootloader = original.IsBootloader;
            DeviceInfo = original.DeviceInfo;
        }

        public void Deconstruct(
            out IMtkDevice Device,
            out bool IsBootloader,
            out MtkDeviceInfo DeviceInfo
        )
        {
            Device = this.Device;
            IsBootloader = this.IsBootloader;
            DeviceInfo = this.DeviceInfo;
        }
    }
}
