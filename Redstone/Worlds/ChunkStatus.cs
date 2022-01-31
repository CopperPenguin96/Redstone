using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jdk.nashorn.@internal.runtime;

namespace Redstone.Worlds
{
    public abstract class ChunkStatus
    {
        public const string Empty = "empty";
        public const string StructureStarts = "structure_starts";
        public const string StructureRefs = "structure_references";
        public const string Biomes = "biomes";
        public const string Noise = "noise";
        public const string Surface = "surface";
        public const string Carvers = "carvers";
        public const string LiquidCarvers = "liquid_carvers";
        public const string Features = "features";
        public const string Light = "light";
        public const string Spawn = "spawn";
        public const string HeightMaps = "heightmaps";
        public const string Full = "full";
    }
}
