using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace mtkclient.library.xflash
{
    internal class MtkDaRegion : IEquatable<MtkDaRegion>
    {
        protected virtual Type EqualityContract
        {
            [CompilerGenerated]
            get { return typeof(MtkDaRegion); }
        }

        public int Buffer { get; set; }

        public int Length { get; set; }

        public uint StartAddress { get; set; }

        public uint StartOffset { get; set; }

        public int SignatureLength { get; set; }

        public MtkDaRegion(
            int Buffer,
            int Length,
            uint StartAddress,
            uint StartOffset,
            int SignatureLength
        )
        {
            this.Buffer = Buffer;
            this.Length = Length;
            this.StartAddress = StartAddress;
            this.StartOffset = StartOffset;
            this.SignatureLength = SignatureLength;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("MtkDaRegion");
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
            builder.Append("Buffer = ");
            builder.Append(Buffer.ToString());
            builder.Append(", Length = ");
            builder.Append(Length.ToString());
            builder.Append(", StartAddress = ");
            builder.Append(StartAddress.ToString());
            builder.Append(", StartOffset = ");
            builder.Append(StartOffset.ToString());
            builder.Append(", SignatureLength = ");
            builder.Append(SignatureLength.ToString());
            return true;
        }

        public static bool operator !=(MtkDaRegion left, MtkDaRegion right)
        {
            return !(left == right);
        }

        public static bool operator ==(MtkDaRegion left, MtkDaRegion right)
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
                                + EqualityComparer<int>.Default.GetHashCode(Buffer)
                            ) * -1521134295
                            + EqualityComparer<int>.Default.GetHashCode(Length)
                        ) * -1521134295
                        + EqualityComparer<uint>.Default.GetHashCode(StartAddress)
                    ) * -1521134295
                    + EqualityComparer<uint>.Default.GetHashCode(StartOffset)
                ) * -1521134295
                + EqualityComparer<int>.Default.GetHashCode(SignatureLength);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MtkDaRegion);
        }

        public virtual bool Equals(MtkDaRegion other)
        {
            if ((object)this != other)
            {
                if (
                    (object)other != null
                    && EqualityContract == other.EqualityContract
                    && EqualityComparer<int>.Default.Equals(Buffer, other.Buffer)
                    && EqualityComparer<int>.Default.Equals(Length, other.Length)
                    && EqualityComparer<uint>.Default.Equals(StartAddress, other.StartAddress)
                    && EqualityComparer<uint>.Default.Equals(StartOffset, other.StartOffset)
                )
                {
                    return EqualityComparer<int>.Default.Equals(
                        SignatureLength,
                        other.SignatureLength
                    );
                }
                return false;
            }
            return true;
        }

        public virtual MtkDaRegion _get()
        {
            return new MtkDaRegion(this);
        }

        protected MtkDaRegion(MtkDaRegion original)
        {
            Buffer = original.Buffer;
            Length = original.Length;
            StartAddress = original.StartAddress;
            StartOffset = original.StartOffset;
            SignatureLength = original.SignatureLength;
        }

        public void Deconstruct(
            out int Buffer,
            out int Length,
            out uint StartAddress,
            out uint StartOffset,
            out int SignatureLength
        )
        {
            Buffer = this.Buffer;
            Length = this.Length;
            StartAddress = this.StartAddress;
            StartOffset = this.StartOffset;
            SignatureLength = this.SignatureLength;
        }
    }
}
