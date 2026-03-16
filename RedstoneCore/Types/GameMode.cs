using Redstone.Core.Utils;

namespace Redstone.Core.Types
{
    public sealed class GameMode : IStaticList<byte>
    {
        public static readonly GameMode Survival = new(0, "survival");
        public static readonly GameMode Creative = new(1, "creative");
        public static readonly GameMode Adventure = new(2, "adventure");
        public static readonly GameMode Spectator = new(3, "spectator");

        public string Name { get; }

        public byte Value { get; }

        private GameMode(byte value, string name)
        {
            Value = value;
            Name = name;
        }

        public override string ToString() => Name;

        public static bool operator ==(GameMode? a, GameMode? b) => ReferenceEquals(a, b);
        public static bool operator !=(GameMode? a, GameMode? b) => !ReferenceEquals(a, b);

        public override bool Equals(object? obj) => ReferenceEquals(this, obj);
        public override int GetHashCode() => Value.GetHashCode();

        public static GameMode Parse(string value) => value.ToLower() switch
        {
            "survival" => Survival,
            "creative" => Creative,
            "adventure" => Adventure,
            "spectator" => Spectator,
            _ => throw new RedstoneException($"Unknown GameMode: {value}")
        };
    }
}
