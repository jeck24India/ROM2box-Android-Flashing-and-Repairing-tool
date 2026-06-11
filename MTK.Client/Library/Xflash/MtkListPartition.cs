using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtkclient.library.xflash
{
    internal class MtkListPartition
    {
        public string name { get; set; }

        public long address { get; set; }

        public long size { get; set; }

        public MtkListPartition[] Partitions { get; set; }

        public MtkListPartition()
        {
            Partitions = new MtkListPartition[0];
        }

        public virtual MtkListPartition _get()
        {
            return new MtkListPartition(this);
        }

        protected MtkListPartition(MtkListPartition original)
        {
            name = original.name;
            address = original.address;
            size = original.size;
        }
    }
}
