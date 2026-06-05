using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace mtkclient.library.xflash
{
    internal class MtkChipConfig : IEquatable<MtkChipConfig>
    {
        public static readonly MtkChipConfig[] ChipConfigs;

        protected virtual Type EqualityContract
        {
            [CompilerGenerated]
            get { return typeof(MtkChipConfig); }
        }

        public uint HardwareCode { get; set; }

        public string Name { get; set; }

        public uint DaCode { get; set; }

        public uint? WdgAddress { get; set; }

        public uint? PayloadAddress { get; set; }

        public uint? UartAddress { get; set; }

        public uint? PtrDl { get; set; }

        public uint? PtrDa { get; set; }

        public uint? Var1 { get; set; }

        public uint? SejBase { get; set; }

        public string PayloadFileName { get; set; }

        public bool UseXFlash { get; set; }

        public MtkChipConfig()
        {
            Name = "";
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("MtkChipConfig");
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
            builder.Append("HardwareCode = ");
            builder.Append(HardwareCode.ToString());
            builder.Append(", Name = ");
            builder.Append((object)Name);
            builder.Append(", DaCode = ");
            builder.Append(DaCode.ToString());
            builder.Append(", WdgAddress = ");
            builder.Append(WdgAddress.ToString());
            builder.Append(", PayloadAddress = ");
            builder.Append(PayloadAddress.ToString());
            builder.Append(", UartAddress = ");
            builder.Append(UartAddress.ToString());
            builder.Append(", PtrDl = ");
            builder.Append(PtrDl.ToString());
            builder.Append(", PtrDa = ");
            builder.Append(PtrDa.ToString());
            builder.Append(", Var1 = ");
            builder.Append(Var1.ToString());
            builder.Append(", SejBase = ");
            builder.Append(SejBase.ToString());
            builder.Append(", PayloadFileName = ");
            builder.Append((object)PayloadFileName);
            builder.Append(", UseXFlash = ");
            builder.Append(UseXFlash.ToString());
            return true;
        }

        public static bool operator !=(MtkChipConfig left, MtkChipConfig right)
        {
            return !(left == right);
        }

        public static bool operator ==(MtkChipConfig left, MtkChipConfig right)
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
                                                    (
                                                        (
                                                            EqualityComparer<Type>.Default.GetHashCode(
                                                                EqualityContract
                                                            ) * -1521134295
                                                            + EqualityComparer<uint>.Default.GetHashCode(
                                                                HardwareCode
                                                            )
                                                        ) * -1521134295
                                                        + EqualityComparer<string>.Default.GetHashCode(
                                                            Name
                                                        )
                                                    ) * -1521134295
                                                    + EqualityComparer<uint>.Default.GetHashCode(
                                                        DaCode
                                                    )
                                                ) * -1521134295
                                                + EqualityComparer<uint?>.Default.GetHashCode(
                                                    WdgAddress
                                                )
                                            ) * -1521134295
                                            + EqualityComparer<uint?>.Default.GetHashCode(
                                                PayloadAddress
                                            )
                                        ) * -1521134295
                                        + EqualityComparer<uint?>.Default.GetHashCode(UartAddress)
                                    ) * -1521134295
                                    + EqualityComparer<uint?>.Default.GetHashCode(PtrDl)
                                ) * -1521134295
                                + EqualityComparer<uint?>.Default.GetHashCode(PtrDa)
                            ) * -1521134295
                            + EqualityComparer<uint?>.Default.GetHashCode(Var1)
                        ) * -1521134295
                        + EqualityComparer<uint?>.Default.GetHashCode(SejBase)
                    ) * -1521134295
                    + EqualityComparer<string>.Default.GetHashCode(PayloadFileName)
                ) * -1521134295
                + EqualityComparer<bool>.Default.GetHashCode(UseXFlash);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MtkChipConfig);
        }

        public virtual bool Equals(MtkChipConfig other)
        {
            if ((object)this != other)
            {
                if (
                    (object)other != null
                    && EqualityContract == other.EqualityContract
                    && EqualityComparer<uint>.Default.Equals(HardwareCode, other.HardwareCode)
                    && EqualityComparer<string>.Default.Equals(Name, other.Name)
                    && EqualityComparer<uint>.Default.Equals(DaCode, other.DaCode)
                    && EqualityComparer<uint?>.Default.Equals(WdgAddress, other.WdgAddress)
                    && EqualityComparer<uint?>.Default.Equals(PayloadAddress, other.PayloadAddress)
                    && EqualityComparer<uint?>.Default.Equals(UartAddress, other.UartAddress)
                    && EqualityComparer<uint?>.Default.Equals(PtrDl, other.PtrDl)
                    && EqualityComparer<uint?>.Default.Equals(PtrDa, other.PtrDa)
                    && EqualityComparer<uint?>.Default.Equals(Var1, other.Var1)
                    && EqualityComparer<uint?>.Default.Equals(SejBase, other.SejBase)
                    && EqualityComparer<string>.Default.Equals(
                        PayloadFileName,
                        other.PayloadFileName
                    )
                )
                {
                    return EqualityComparer<bool>.Default.Equals(UseXFlash, other.UseXFlash);
                }
                return false;
            }
            return true;
        }

        public virtual MtkChipConfig _get()
        {
            return new MtkChipConfig(this);
        }

        protected MtkChipConfig(MtkChipConfig original)
        {
            HardwareCode = original.HardwareCode;
            Name = original.Name;
            DaCode = original.DaCode;
            WdgAddress = original.WdgAddress;
            PayloadAddress = original.PayloadAddress;
            UartAddress = original.UartAddress;
            PtrDl = original.PtrDl;
            PtrDa = original.PtrDa;
            Var1 = original.Var1;
            SejBase = original.SejBase;
            PayloadFileName = original.PayloadFileName;
            UseXFlash = original.UseXFlash;
        }

        static MtkChipConfig()
        {
            ChipConfigs = new MtkChipConfig[31]
            {
                new MtkChipConfig
                {
                    HardwareCode = 2450u,
                    Name = "MT0992",
                    DaCode = 2450u,
                    WdgAddress = null,
                    PayloadAddress = null,
                    UartAddress = null,
                    PtrDl = null,
                    PtrDa = null,
                    Var1 = null,
                    SejBase = null,
                    PayloadFileName = null,
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 1587u,
                    Name = "MT6570",
                    DaCode = 25968u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = null,
                    PtrDa = null,
                    Var1 = null,
                    SejBase = 268476416u,
                    PayloadFileName = null,
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 1689u,
                    Name = "MT6739/MT6731",
                    DaCode = 26425u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 57116u,
                    PtrDa = 58344u,
                    Var1 = 180u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt6739_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 1537u,
                    Name = "MT6750",
                    DaCode = 26453u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = null,
                    PtrDa = null,
                    Var1 = 10u,
                    SejBase = 268476416u,
                    PayloadFileName = null,
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 806u,
                    Name = "MT6755/MT6750/M/T/S",
                    DaCode = 26453u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 39532u,
                    PtrDa = 40724u,
                    Var1 = 10u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt6755_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 1361u,
                    Name = "MT6757/MT6757D",
                    DaCode = 26455u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 39980u,
                    PtrDa = 41192u,
                    Var1 = 10u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt6757_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 1672u,
                    Name = "MT6758",
                    DaCode = 26456u,
                    WdgAddress = 270602240u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285343744u,
                    PtrDl = 55392u,
                    PtrDa = 56620u,
                    Var1 = 10u,
                    SejBase = 268959744u,
                    PayloadFileName = "mt6758_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 1815u,
                    Name = "MT6761/MT6762/MT3369/MT8766B",
                    DaCode = 26465u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 48268u,
                    PtrDa = 49496u,
                    Var1 = 37u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt6761_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 1680u,
                    Name = "MT6763",
                    DaCode = 26467u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 54892u,
                    PtrDa = 56120u,
                    Var1 = 127u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt6763_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 1894u,
                    Name = "MT6765/MT8768t",
                    DaCode = 26469u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 48576u,
                    PtrDa = 49804u,
                    Var1 = 37u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt6765_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 1799u,
                    Name = "MT6768",
                    DaCode = 26472u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 49552u,
                    PtrDa = 50768u,
                    Var1 = 37u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt6768_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 1928u,
                    Name = "MT6771/MT8385/MT8183/MT8666",
                    DaCode = 26481u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 57020u,
                    PtrDa = 58248u,
                    Var1 = 10u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt6771_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 1829u,
                    Name = "MT6779",
                    DaCode = 26489u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 57420u,
                    PtrDa = 58636u,
                    Var1 = 10u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt6779_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 4198u,
                    Name = "MT6781",
                    DaCode = 26497u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 58840u,
                    PtrDa = 60052u,
                    Var1 = 115u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt6781_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 2067u,
                    Name = "MT6785",
                    DaCode = 26501u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 58020u,
                    PtrDa = 59236u,
                    Var1 = 10u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt6785_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 633u,
                    Name = "MT6797/MT6767",
                    DaCode = 26519u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 40620u,
                    PtrDa = 41812u,
                    Var1 = 10u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt6797_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 1378u,
                    Name = "MT6799",
                    DaCode = 26521u,
                    WdgAddress = 270602240u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285343744u,
                    PtrDl = 62892u,
                    PtrDa = 64120u,
                    Var1 = 10u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt6799_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 2441u,
                    Name = "MT6833",
                    DaCode = 26675u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 57312u,
                    PtrDa = 58528u,
                    Var1 = 115u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt6833_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 2454u,
                    Name = "MT6853",
                    DaCode = 26707u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 60004u,
                    PtrDa = 61220u,
                    Var1 = 10u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt6853_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 2182u,
                    Name = "MT6873",
                    DaCode = 26739u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 60024u,
                    PtrDa = 61240u,
                    Var1 = 10u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt6873_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 2393u,
                    Name = "MT6877",
                    DaCode = 26743u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 59600u,
                    PtrDa = 60816u,
                    Var1 = 10u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt6877_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 2070u,
                    Name = "MT6885/MT6883/MT6889/MT6880/MT6890",
                    DaCode = 26757u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 59132u,
                    PtrDa = 60348u,
                    Var1 = 10u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt6885_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 2384u,
                    Name = "MT6893",
                    DaCode = 26771u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 59292u,
                    PtrDa = 60508u,
                    Var1 = 10u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt6893_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 33040u,
                    Name = "MT8110",
                    DaCode = 33040u,
                    WdgAddress = null,
                    PayloadAddress = null,
                    UartAddress = null,
                    PtrDl = null,
                    PtrDa = null,
                    Var1 = null,
                    SejBase = null,
                    PayloadFileName = null,
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 33127u,
                    Name = "MT8167/MT8516/MT8362",
                    DaCode = 33127u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285233152u,
                    PtrDl = 53988u,
                    PtrDa = 55212u,
                    Var1 = 204u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt8167_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 33128u,
                    Name = "MT8168",
                    DaCode = 33128u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = null,
                    PtrDa = null,
                    Var1 = null,
                    SejBase = null,
                    PayloadFileName = null,
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 2352u,
                    Name = "MT8195",
                    DaCode = 33173u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285217280u,
                    PtrDl = null,
                    PtrDa = null,
                    Var1 = null,
                    SejBase = null,
                    PayloadFileName = null,
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 34066u,
                    Name = "MT8512",
                    DaCode = 34066u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 52292u,
                    PtrDa = 53652u,
                    Var1 = 10u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt8512_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 34072u,
                    Name = "MT8518",
                    DaCode = 34072u,
                    WdgAddress = null,
                    PayloadAddress = null,
                    UartAddress = null,
                    PtrDl = null,
                    PtrDa = null,
                    Var1 = null,
                    SejBase = null,
                    PayloadFileName = null,
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 34453u,
                    Name = "MT8695",
                    DaCode = 34453u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = 285220864u,
                    PtrDl = 48876u,
                    PtrDa = 50168u,
                    Var1 = 10u,
                    SejBase = 268476416u,
                    PayloadFileName = "mt8695_payload.bin",
                    UseXFlash = true
                },
                new MtkChipConfig
                {
                    HardwareCode = 2312u,
                    Name = "MT8696",
                    DaCode = 34454u,
                    WdgAddress = 268464128u,
                    PayloadAddress = 1051136u,
                    UartAddress = null,
                    PtrDl = null,
                    PtrDa = null,
                    Var1 = null,
                    SejBase = null,
                    PayloadFileName = null,
                    UseXFlash = true
                }
            };
        }
    }
}
