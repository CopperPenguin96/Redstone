using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Worlds.Dimensions
{
    public abstract class Dimension
    {
        public virtual Identifier Type { get; set; }

        public virtual Identifier GenType { get; set; }

        public virtual Identifier Settings { get; set; }

        public virtual Identifier BiomeSourceType { get; set; }
    }
}
