using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace mtkclient.library
{
    internal class MtkDaxUploadCalculationResult : IEquatable<MtkDaxUploadCalculationResult>
    {
        protected virtual Type EqualityContract
        {
            [CompilerGenerated]
            get { return typeof(MtkDaxUploadCalculationResult); }
        }

        public byte[] Da1 { get; set; }

        public byte[] Da2 { get; set; }

        public byte[] Extension { get; set; }

        public MtkDaxUploadCalculationResult(byte[] Da1, byte[] Da2, byte[] Extension)
        {
            this.Da1 = Da1;
            this.Da2 = Da2;
            this.Extension = Extension;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("MtkDaxUploadCalculationResult");
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
            builder.Append("Da1 = ");
            builder.Append(Da1);
            builder.Append(", Da2 = ");
            builder.Append(Da2);
            builder.Append(", Extension = ");
            builder.Append(Extension);
            return true;
        }

        public static bool operator !=(
            MtkDaxUploadCalculationResult left,
            MtkDaxUploadCalculationResult right
        )
        {
            return !(left == right);
        }

        public static bool operator ==(
            MtkDaxUploadCalculationResult left,
            MtkDaxUploadCalculationResult right
        )
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
                        + EqualityComparer<byte[]>.Default.GetHashCode(Da1)
                    ) * -1521134295
                    + EqualityComparer<byte[]>.Default.GetHashCode(Da2)
                ) * -1521134295
                + EqualityComparer<byte[]>.Default.GetHashCode(Extension);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MtkDaxUploadCalculationResult);
        }

        public virtual bool Equals(MtkDaxUploadCalculationResult other)
        {
            if ((object)this != other)
            {
                if (
                    (object)other != null
                    && EqualityContract == other.EqualityContract
                    && EqualityComparer<byte[]>.Default.Equals(Da1, other.Da1)
                    && EqualityComparer<byte[]>.Default.Equals(Da2, other.Da2)
                )
                {
                    return EqualityComparer<byte[]>.Default.Equals(Extension, other.Extension);
                }
                return false;
            }
            return true;
        }

        public virtual MtkDaxUploadCalculationResult _get()
        {
            return new MtkDaxUploadCalculationResult(this);
        }

        protected MtkDaxUploadCalculationResult(MtkDaxUploadCalculationResult original)
        {
            Da1 = original.Da1;
            Da2 = original.Da2;
            Extension = original.Extension;
        }

        public void Deconstruct(out byte[] Da1, out byte[] Da2, out byte[] Extension)
        {
            Da1 = this.Da1;
            Da2 = this.Da2;
            Extension = this.Extension;
        }
    }
}
