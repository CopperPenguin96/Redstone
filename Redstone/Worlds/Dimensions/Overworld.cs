using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Worlds.Dimensions
{
    public class Overworld : Dimension
    {
        public override Identifier Type => "overworld";

        public override Identifier GenType => "noise";

        public override Identifier Settings => "overworld";

        public bool LargeBiomes { get; set; } = false;

        public override Identifier BiomeSourceType => "vanilla_layered";
    }
}
