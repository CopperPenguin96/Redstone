using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Worlds.Dimensions
{
    public class CheckerboardNoiseDimension : NoiseDimension
    {
        public List<Biome> Biomes { get; set; }

        public int Scale { get; set; }

        public override string BiomeSourceType => BiomeSourceTypes.Checkerboard;
    }
}
