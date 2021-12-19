using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Worlds
{
    public sealed class BiomeGeneration
    {
        public const string MultiNoise = "multi_noise";

        public const string Fixed = "fixed";

        public const string Checkerboard = "checkerboard";

        public const string TheEnd = "the_end";

        public const string VanillaLayered = "vanilla_layered";

        public string Generator { get; set; }

        public List<string> BiomePreset { get; set; }

        public List<Biome> Biomes { get; set; }


    }
}
