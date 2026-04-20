using Redstone.Core.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Redstone.Core.World
{
    public class Biome(Identifier id)
    {
        public Identifier ID { get; private set; } = id;

        public bool HasPrecipitation { get; set; }

        public float Temperature { get; set; }

        public bool IsFrozen { get; set; }

        public float Downfall { get; set; }

        public Color WaterColor { get; set; }

        public Color FoliageColor { get; set; }

        public Color DryFoliageColor { get; set; }

        public Color GrassColor { get; set; }

        public GrassColorModifier GrassColorModifier { get; set; }


    }

    public enum GrassColorModifier
    {
        None,
        DarkForest,
        Swamp
    }
}
