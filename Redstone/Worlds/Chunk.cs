using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Worlds
{
    public class Chunk
    {
        public byte ColumnY { get; set; }

        public byte[] BlockLight { get; set; }

        public byte[] Blocks { get; set; }

        public byte[] Data { get; set; }

        public byte[] Skylight { get; set; }
    }
}
