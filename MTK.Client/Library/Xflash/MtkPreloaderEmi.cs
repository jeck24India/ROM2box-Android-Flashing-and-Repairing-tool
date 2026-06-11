using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace mtkclient.library.xflash
{
    internal class MtkPreloaderEmi : IEquatable<MtkPreloaderEmi>
    {
        protected virtual Type EqualityContract
        {
            [CompilerGenerated]
            get { return typeof(MtkPreloaderEmi); }
        }

        public uint Version { get; set; }

        public byte[] Emi { get; set; }

        public MtkPreloaderEmi(uint Version, byte[] Emi)
        {
            this.Version = Version;
            this.Emi = Emi;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("MtkPreloaderEmi");
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
            builder.Append("Version = ");
            builder.Append(Version.ToString());
            builder.Append(", Emi = ");
            builder.Append(Emi);
            return true;
        }

        public static bool operator !=(MtkPreloaderEmi left, MtkPreloaderEmi right)
        {
            return !(left == right);
        }

        public static bool operator ==(MtkPreloaderEmi left, MtkPreloaderEmi right)
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
                    EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295
                    + EqualityComparer<uint>.Default.GetHashCode(Version)
                ) * -1521134295
                + EqualityComparer<byte[]>.Default.GetHashCode(Emi);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MtkPreloaderEmi);
        }

        public virtual bool Equals(MtkPreloaderEmi other)
        {
            if ((object)this != other)
            {
                if (
                    (object)other != null
                    && EqualityContract == other.EqualityContract
                    && EqualityComparer<uint>.Default.Equals(Version, other.Version)
                )
                {
                    return EqualityComparer<byte[]>.Default.Equals(Emi, other.Emi);
                }
                return false;
            }
            return true;
        }

        public virtual MtkPreloaderEmi _get()
        {
            return new MtkPreloaderEmi(this);
        }

        protected MtkPreloaderEmi(MtkPreloaderEmi original)
        {
            Version = original.Version;
            Emi = original.Emi;
        }

        public void Deconstruct(out uint Version, out byte[] Emi)
        {
            Version = this.Version;
            Emi = this.Emi;
        }
    }
}
