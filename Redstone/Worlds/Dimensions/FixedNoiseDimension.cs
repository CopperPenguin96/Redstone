using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Worlds.Dimensions
{
    /// <summary>
    /// A single biome noise dimension.
    /// </summary>
    public class FixedNoiseDimension : NoiseDimension
    {
        public Biome Biome { get; set; }

        public override string BiomeSourceType => BiomeSourceTypes.Fixed;
    }
}
