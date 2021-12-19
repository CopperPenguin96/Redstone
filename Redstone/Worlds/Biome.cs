using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Worlds
{
    public enum BiomeType : byte
    {
        Ocean = 0,
        Plains = 1,
        Desert = 2,
        ExtremeHills = 3,
        Forest = 4,
        Taiga = 5,
        Swampland = 6,
        River = 7,
        Hell = 8,
        Sky = 9,
        FrozenOcean = 10,
        FrozenRiver = 11,
        IcePlains = 12,
        IceMountains = 13,
        MushroomIsland = 14,
        MushroomIslandShore = 15,
        Beach = 16,
        DesertHills = 17,
        ForestHills = 18,
        TaigaHills = 19,
        ExtremeHillsEdge = 20,
        Jungle = 21,
        JungleHills = 22
    }

    public class Biome
    {
        public string Name { get; set; }

        public float Temparature { get; set; }

        public float Humidity { get; set; }

        public float Continentalness { get; set; }

        public float Erosion { get; set; }

        public float Weirdness { get; set; }

        public float Depth { get; set; }

        public float Offset { get; set; }
    }
}
