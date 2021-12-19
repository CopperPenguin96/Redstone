using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds.Dimensions
{
    public abstract class DimensionType
    {
        public static readonly Identifier Overworld = "overworld";

        public static readonly Identifier OverworldCaves = "overworld_caves";

        public static readonly Identifier Nether = "the_nether";

        public static readonly Identifier End = "the_end";
    }
}
