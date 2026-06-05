using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace mtkclient.library
{
    internal class MtkDaxFlashInfo : IEquatable<MtkDaxFlashInfo>
    {
        protected virtual Type EqualityContract
        {
            [CompilerGenerated]
            get { return typeof(MtkDaxFlashInfo); }
        }

        public MtkDaxFlashInfoType Type { get; set; }

        public long[] FlashSizes { get; set; }

        public long RpmbSize { get; set; }

        public long Boot1Size { get; set; }

        public long Boot2Size { get; set; }

        public int PageSize { get; set; }

        public int WriteBufferSize { get; set; }

        public int ReadBufferSize { get; set; }

        public MtkDaxFlashInfo()
        {
            FlashSizes = new long[0];
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("MtkDaxFlashInfo");
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
            builder.Append("Type = ");
            builder.Append(Type.ToString());
            builder.Append(", FlashSizes = ");
            builder.Append(FlashSizes);
            builder.Append(", RpmbSize = ");
            builder.Append(RpmbSize.ToString());
            builder.Append(", Boot1Size = ");
            builder.Append(Boot1Size.ToString());
            builder.Append(", Boot2Size = ");
            builder.Append(Boot2Size.ToString());
            builder.Append(", PageSize = ");
            builder.Append(PageSize.ToString());
            builder.Append(", WriteBufferSize = ");
            builder.Append(WriteBufferSize.ToString());
            builder.Append(", ReadBufferSize = ");
            builder.Append(ReadBufferSize.ToString());
            return true;
        }

        public static bool operator !=(MtkDaxFlashInfo left, MtkDaxFlashInfo right)
        {
            return !(left == right);
        }

        public static bool operator ==(MtkDaxFlashInfo left, MtkDaxFlashInfo right)
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
                                            EqualityComparer<global::System.Type>.Default.GetHashCode(
                                                EqualityContract
                                            ) * -1521134295
                                            + EqualityComparer<MtkDaxFlashInfoType>.Default.GetHashCode(
                                                Type
                                            )
                                        ) * -1521134295
                                        + EqualityComparer<long[]>.Default.GetHashCode(FlashSizes)
                                    ) * -1521134295
                                    + EqualityComparer<long>.Default.GetHashCode(RpmbSize)
                                ) * -1521134295
                                + EqualityComparer<long>.Default.GetHashCode(Boot1Size)
                            ) * -1521134295
                            + EqualityComparer<long>.Default.GetHashCode(Boot2Size)
                        ) * -1521134295
                        + EqualityComparer<int>.Default.GetHashCode(PageSize)
                    ) * -1521134295
                    + EqualityComparer<int>.Default.GetHashCode(WriteBufferSize)
                ) * -1521134295
                + EqualityComparer<int>.Default.GetHashCode(ReadBufferSize);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MtkDaxFlashInfo);
        }

        public virtual bool Equals(MtkDaxFlashInfo other)
        {
            if ((object)this != other)
            {
                if (
                    (object)other != null
                    && EqualityContract == other.EqualityContract
                    && EqualityComparer<MtkDaxFlashInfoType>.Default.Equals(Type, other.Type)
                    && EqualityComparer<long[]>.Default.Equals(FlashSizes, other.FlashSizes)
                    && EqualityComparer<long>.Default.Equals(RpmbSize, other.RpmbSize)
                    && EqualityComparer<long>.Default.Equals(Boot1Size, other.Boot1Size)
                    && EqualityComparer<long>.Default.Equals(Boot2Size, other.Boot2Size)
                    && EqualityComparer<int>.Default.Equals(PageSize, other.PageSize)
                    && EqualityComparer<int>.Default.Equals(WriteBufferSize, other.WriteBufferSize)
                )
                {
                    return EqualityComparer<int>.Default.Equals(
                        ReadBufferSize,
                        other.ReadBufferSize
                    );
                }
                return false;
            }
            return true;
        }

        public virtual MtkDaxFlashInfo _get()
        {
            return new MtkDaxFlashInfo(this);
        }

        protected MtkDaxFlashInfo(MtkDaxFlashInfo original)
        {
            Type = original.Type;
            FlashSizes = original.FlashSizes;
            RpmbSize = original.RpmbSize;
            Boot1Size = original.Boot1Size;
            Boot2Size = original.Boot2Size;
            PageSize = original.PageSize;
            WriteBufferSize = original.WriteBufferSize;
            ReadBufferSize = original.ReadBufferSize;
        }
    }
}
