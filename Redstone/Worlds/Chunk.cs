using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Worlds
{
    public class Chunk
    {
        public const int DataVersion = 0;

        /// <summary>
        /// Position of the chunk.
        /// X & Z are not relative to region.
        /// Y is the lowest section of the chunk
        /// </summary>
        public Position Position { get; set; }

        public string Status { get; set; }

        public long LastUpdate { get; set; }


    }
}
