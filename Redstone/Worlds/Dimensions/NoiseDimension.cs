using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds.Dimensions
{
    public abstract class NoiseDimension : IDimension
    {
        public Identifier Type { get; set; }

        public Identifier Id => "noise";

        public long Seed { get; set; }

        public virtual string BiomeSourceType { get; set; }


    /* TODO implement custom settings
    public int SeaLevel { get; set; }

    public bool DisableMobGeneration { get; set; }

    public bool NoiseCavesEnabled { get; set; }

    public bool NoodleCavesEnabled { get; set; }

    public bool OreVeinsEnabled { get; set; }

    public bool AquifersEnabled { get; set; }

    public bool LegacyRandomSource { get; set; }

    public Block DefaultBlock { get; set; }

    public Block DefaultFluid { get; set; }

    public StrongholdSettings StrongholdSettings { get; set; }

    public List<Structure> Structures { get; set; }

    public int MinY { get; set; }

    public int Height { get; set; }

    public int SizeHorizontal { get; set; }

    public int SizeVertical { get; set; }

    public bool IslandNoiseOverride { get; set; }

    public bool Amplified { get; set; }

    public bool LargeBiomes { get; set; }

    public double XZScale { get; set; }

    public double XZFactor { get; set; }

    public double YScale { get; set; }

    public double YFactor { get; set; }

    public int TopSlideTarget { get; set; }

    public int TopSlideSize { get; set; }
    
    public int TopSlideOffset { get; set; }

    public int BottomSlideTarget { get; set; }

    public int BottomSlideSize { get; set; }

    public int BottomSlideOffset { get; set; }

    public float TerrainShaperOffset { get; set; }

    public float TerrainShaperFactor { get; set; }

    public float TerrainShaperJaggedness { get; set; }*/
    }
}
