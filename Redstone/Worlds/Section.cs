using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Worlds
{
    public class Section
    {
        public byte Y { get; set; }

        public List<Block> Blocks { get; set; }

        public long[] BlockStates { get; set; }

        public byte[] BlockLight = new byte[2048];

        public byte[] SkyLight = new byte[2048];
    }
}
