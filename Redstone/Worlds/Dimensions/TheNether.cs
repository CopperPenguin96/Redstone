using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds.Dimensions
{
    public class TheNether : Dimension
    {
        public override Identifier Type => "the_nether";

        public override Identifier GenType => "noise";

        public override Identifier Settings => "nether";

        public Identifier Preset { get; set; } = "nether";

        public override Identifier BiomeSourceType => "multi_noise";
    }
}
