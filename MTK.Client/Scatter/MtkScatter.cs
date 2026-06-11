using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtkclient.MTK.Client.Scatter
{
    public class MtkScatter
    {
        public static string CPU { get; set; }
        public static string CPUType { get; set; }
        public static string Cache { get; set; }
        public static string Userdata { get; set; }
        public static string Cachepath { get; set; }
        public static string Userpath { get; set; }

        public static bool IsSupport(string scatter)
        {
            bool result = false;
            try
            {
                bool flag = false;
                string s = File.ReadAllText(scatter);
                using (StringReader stringReader = new StringReader(s))
                {
                    while (stringReader.Peek() != -1)
                    {
                        string text = stringReader.ReadLine();
                        if (text.Contains("platform:"))
                        {
                            CPU = text.Substring(text.IndexOf(":") + 2);
                            flag = true;
                        }
                        else if (text.Contains("storage: EMMC"))
                        {
                            CPUType = "EMMC";
                        }
                        else if (text.Contains("storage: NAND"))
                        {
                            CPUType = "NAND";
                        }
                        else if (text.Contains("storage: UFS"))
                        {
                            CPUType = "UFS";
                        }
                    }
                }
                result = flag;
            }
            catch
            {
                Console.WriteLine("Scatter cant support !");
            }
            return result;
        }

        public class mtk
        {
            public string Partition_index;
            public string Partition_name;
            public string File_name;
            public string Is_download;
            public string Linear_start_addr;
            public string Partition_size;

            public mtk(
                string Partition_index,
                string Partition_name,
                string File_name,
                string Is_download,
                string Linear_start_addr,
                string Partition_size
            )
            {
                this.Partition_index = Partition_index;
                this.Partition_name = Partition_name;
                this.File_name = File_name;
                this.Is_download = Is_download;
                this.Linear_start_addr = Linear_start_addr;
                this.Partition_size = Partition_size;
            }
        }

        public static List<mtk> ScatterTable(string Scatterfile)
        {
            List<mtk> list = new List<mtk>();
            string text = File.ReadAllText(Scatterfile)
                .Replace("- partition_index:", "+ partition_index:");
            string[] array = text.Split(new char[] { '+' });
            foreach (string text2 in array)
            {
                if (text2.Contains("partition_name"))
                {
                    string partition_index = "";
                    string partition_name = "";
                    string file_name = "";
                    string is_download = "";
                    string linear_start_addr = "";
                    string partition_size = "";
                    using (StringReader stringReader = new StringReader(text2))
                    {
                        while (stringReader.Peek() != -1)
                        {
                            string text3 = stringReader.ReadLine();
                            if (text3.Contains("partition_index"))
                            {
                                partition_index = text3
                                    .Substring(text3.IndexOf(":") + 2)
                                    .Replace("SYS", "");
                            }
                            if (text3.Contains("partition_name"))
                            {
                                partition_name = text3.Substring(text3.IndexOf(":") + 2);
                            }
                            if (text3.Contains("file_name"))
                            {
                                file_name = text3.Substring(text3.IndexOf(":") + 2);
                            }
                            if (text3.Contains("is_download"))
                            {
                                is_download = text3.Substring(text3.IndexOf(":") + 2);
                            }
                            if (text3.Contains("linear_start_addr"))
                            {
                                linear_start_addr = text3.Substring(text3.IndexOf(":") + 2);
                            }
                            if (text3.Contains("partition_size"))
                            {
                                partition_size = text3.Substring(text3.IndexOf(":") + 2);
                            }
                        }
                    }
                    list.Add(
                        new mtk(
                            partition_index,
                            partition_name,
                            file_name,
                            is_download,
                            linear_start_addr,
                            partition_size
                        )
                    );
                }
            }
            return list;
        }

        public class Firmware
        {
            public string Index { get; set; }
            public string Filepath { get; set; }

            public Firmware(string Index, string Filepath)
            {
                this.Index = Index;
                this.Filepath = Filepath;
            }
        }
    }

    public class Mediatek
    {
        public static string DA { get; set; }
        public static string Auth { get; set; }
        public static string Scatterfile { get; set; }
        public static string Preloader { get; set; }
        public static string Connection { get; set; }
        public static string Preloaderunlock { get; set; }
        public static string PreloaderEmi { get; set; }
        public static string Savepartition { get; set; }
    }
}
