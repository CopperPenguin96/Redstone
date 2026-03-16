using Redstone.Core;
using Redstone.Core.Types;
using Redstone.Core.Utils;

namespace Redstone.World
{
    public sealed class LevelType : IStaticList<byte>
    {
        public static readonly LevelType Normal = new(0, "normal");
        public static readonly LevelType Flat = new(1, "flat");
        public static readonly LevelType LargeBiomes = new(2, "large_biomes");
        public static readonly LevelType Amplified = new(3, "amplified");
        public static readonly LevelType SingleBiome = new(4, "single_biome_surface");

        public Identifier Ident { get; }

        public byte Value { get; }

        public string Name => Ident.ToString();

        private LevelType(byte value, Identifier id)
        {
            Value = value;
            Ident = id;
        }

        public override string ToString() => Ident.ToString();

        public static bool operator ==(LevelType? a, LevelType? b) => ReferenceEquals(a, b);
        public static bool operator !=(LevelType? a, LevelType? b) => !ReferenceEquals(a, b);

        public override bool Equals(object? obj) => ReferenceEquals(this, obj);
        public override int GetHashCode() => Value.GetHashCode();

        public static LevelType Parse(string value) => value.ToLower() switch
        {
            "minecraft:normal" => Normal,
            "minecraft:flat" => Flat,
            "minecraft:large_biomes" => LargeBiomes,
            "minecraft:amplified" => Amplified,
            "minecraft:single_biome_surface" => SingleBiome,
            _ => throw new RedstoneException($"Unknown LevelType: {value}")
        };
    }
}
