using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace mtkclient.library.xflash
{
    internal class MtkPreloaderIndex : IEquatable<MtkPreloaderIndex>
    {
        protected virtual Type EqualityContract
        {
            [CompilerGenerated]
            get { return typeof(MtkPreloaderIndex); }
        }

        public int Index { get; set; }

        public int Length { get; set; }

        public MtkPreloaderIndex(int Index, int Length)
        {
            this.Index = Index;
            this.Length = Length;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("MtkPreloaderIndex");
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
            builder.Append("Index = ");
            builder.Append(Index.ToString());
            builder.Append(", Length = ");
            builder.Append(Length.ToString());
            return true;
        }

        public static bool operator !=(MtkPreloaderIndex left, MtkPreloaderIndex right)
        {
            return !(left == right);
        }

        public static bool operator ==(MtkPreloaderIndex left, MtkPreloaderIndex right)
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
                    + EqualityComparer<int>.Default.GetHashCode(Index)
                ) * -1521134295
                + EqualityComparer<int>.Default.GetHashCode(Length);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MtkPreloaderIndex);
        }

        public virtual bool Equals(MtkPreloaderIndex other)
        {
            if ((object)this != other)
            {
                if (
                    (object)other != null
                    && EqualityContract == other.EqualityContract
                    && EqualityComparer<int>.Default.Equals(Index, other.Index)
                )
                {
                    return EqualityComparer<int>.Default.Equals(Length, other.Length);
                }
                return false;
            }
            return true;
        }

        public virtual MtkPreloaderIndex _get()
        {
            return new MtkPreloaderIndex(this);
        }

        protected MtkPreloaderIndex(MtkPreloaderIndex original)
        {
            Index = original.Index;
            Length = original.Length;
        }

        public void Deconstruct(out int Index, out int Length)
        {
            Index = this.Index;
            Length = this.Length;
        }
    }
}
