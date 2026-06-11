using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace mtkclient.library.xflash
{
    internal class MtkGptPartition : IEquatable<MtkGptPartition>
    {
        protected virtual Type EqualityContract
        {
            get { return typeof(MtkGptPartition); }
        }

        public int Type { get; set; }

        public Guid Id { get; set; }

        public long FirstLba { get; set; }

        public long LastLba { get; set; }

        public long Flags { get; set; }

        public string Name { get; set; }

        public long SectorCount => LastLba - FirstLba + 1L;

        public MtkGptPartition()
        {
            Name = "";
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("MtkGptPartition");
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
            builder.Append(", Id = ");
            builder.Append(Id.ToString());
            builder.Append(", FirstLba = ");
            builder.Append(FirstLba.ToString());
            builder.Append(", LastLba = ");
            builder.Append(LastLba.ToString());
            builder.Append(", Flags = ");
            builder.Append(Flags.ToString());
            builder.Append(", Name = ");
            builder.Append((object)Name);
            builder.Append(", SectorCount = ");
            builder.Append(SectorCount.ToString());
            return true;
        }

        public static bool operator !=(MtkGptPartition left, MtkGptPartition right)
        {
            return !(left == right);
        }

        public static bool operator ==(MtkGptPartition left, MtkGptPartition right)
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
                                    EqualityComparer<global::System.Type>.Default.GetHashCode(
                                        EqualityContract
                                    ) * -1521134295
                                    + EqualityComparer<int>.Default.GetHashCode(Type)
                                ) * -1521134295
                                + EqualityComparer<Guid>.Default.GetHashCode(Id)
                            ) * -1521134295
                            + EqualityComparer<long>.Default.GetHashCode(FirstLba)
                        ) * -1521134295
                        + EqualityComparer<long>.Default.GetHashCode(LastLba)
                    ) * -1521134295
                    + EqualityComparer<long>.Default.GetHashCode(Flags)
                ) * -1521134295
                + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MtkGptPartition);
        }

        public virtual bool Equals(MtkGptPartition other)
        {
            if ((object)this != other)
            {
                if (
                    (object)other != null
                    && EqualityContract == other.EqualityContract
                    && EqualityComparer<int>.Default.Equals(Type, other.Type)
                    && EqualityComparer<Guid>.Default.Equals(Id, other.Id)
                    && EqualityComparer<long>.Default.Equals(FirstLba, other.FirstLba)
                    && EqualityComparer<long>.Default.Equals(LastLba, other.LastLba)
                    && EqualityComparer<long>.Default.Equals(Flags, other.Flags)
                )
                {
                    return EqualityComparer<string>.Default.Equals(Name, other.Name);
                }
                return false;
            }
            return true;
        }

        public virtual MtkGptPartition _get()
        {
            return new MtkGptPartition(this);
        }

        protected MtkGptPartition(MtkGptPartition original)
        {
            Type = original.Type;
            Id = original.Id;
            FirstLba = original.FirstLba;
            LastLba = original.LastLba;
            Flags = original.Flags;
            Name = original.Name;
        }
    }
}
