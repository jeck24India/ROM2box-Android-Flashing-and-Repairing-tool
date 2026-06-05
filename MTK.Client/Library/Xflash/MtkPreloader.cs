using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace mtkclient.library.xflash
{
    internal class MtkPreloader : IEquatable<MtkPreloader>
    {
        protected virtual Type EqualityContract
        {
            [CompilerGenerated]
            get { return typeof(MtkPreloader); }
        }

        public string Name { get; set; }

        public uint Version { get; set; }

        public byte[] Emi { get; set; }

        public byte[] Data { get; set; }

        public MtkPreloader(string Name, uint Version, byte[] Emi, byte[] Data)
        {
            this.Name = Name;
            this.Version = Version;
            this.Emi = Emi;
            this.Data = Data;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("MtkPreloader");
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
            builder.Append("Name = ");
            builder.Append((object)Name);
            builder.Append(", Version = ");
            builder.Append(Version.ToString());
            builder.Append(", Emi = ");
            builder.Append(Emi);
            builder.Append(", Data = ");
            builder.Append(Data);
            return true;
        }

        public static bool operator !=(MtkPreloader left, MtkPreloader right)
        {
            return !(left == right);
        }

        public static bool operator ==(MtkPreloader left, MtkPreloader right)
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
                            EqualityComparer<Type>.Default.GetHashCode(EqualityContract)
                                * -1521134295
                            + EqualityComparer<string>.Default.GetHashCode(Name)
                        ) * -1521134295
                        + EqualityComparer<uint>.Default.GetHashCode(Version)
                    ) * -1521134295
                    + EqualityComparer<byte[]>.Default.GetHashCode(Emi)
                ) * -1521134295
                + EqualityComparer<byte[]>.Default.GetHashCode(Data);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MtkPreloader);
        }

        public virtual bool Equals(MtkPreloader other)
        {
            if ((object)this != other)
            {
                if (
                    (object)other != null
                    && EqualityContract == other.EqualityContract
                    && EqualityComparer<string>.Default.Equals(Name, other.Name)
                    && EqualityComparer<uint>.Default.Equals(Version, other.Version)
                    && EqualityComparer<byte[]>.Default.Equals(Emi, other.Emi)
                )
                {
                    return EqualityComparer<byte[]>.Default.Equals(Data, other.Data);
                }
                return false;
            }
            return true;
        }

        public virtual MtkPreloader _get()
        {
            return new MtkPreloader(this);
        }

        protected MtkPreloader(MtkPreloader original)
        {
            Name = original.Name;
            Version = original.Version;
            Emi = original.Emi;
            Data = original.Data;
        }

        public void Deconstruct(out string Name, out uint Version, out byte[] Emi, out byte[] Data)
        {
            Name = this.Name;
            Version = this.Version;
            Emi = this.Emi;
            Data = this.Data;
        }
    }
}
