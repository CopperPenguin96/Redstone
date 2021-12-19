using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds.Dimensions
{
    public class MultiNoiseDimension : NoiseDimension
    {
        public Identifier Preset { get; set; }

        public List<Biome> Biomes { get; set; }
        
        public bool LargeBiomes { get; set; }

        public bool LegacyBiomeInitLayer { get; set; }
    }
}
