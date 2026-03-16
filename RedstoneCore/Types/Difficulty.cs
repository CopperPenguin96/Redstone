using Redstone.Core.Utils;

namespace Redstone.Core.Types
{
    public sealed class Difficulty : IStaticList<byte>
    {
        public static readonly Difficulty Peaceful = new(0, "peaceful");
        public static readonly Difficulty Easy = new(1, "easy");
        public static readonly Difficulty Normal = new(2, "normal");
        public static readonly Difficulty Hard = new(3, "hard");

        public string Name { get; }

        public byte Value { get; }

        private Difficulty(byte value, string name)
        {
            Value = value;
            Name = name;
        }

        public override string ToString() => Name;

        public static bool operator ==(Difficulty? a, Difficulty? b) => ReferenceEquals(a, b);
        public static bool operator !=(Difficulty? a, Difficulty? b) => !ReferenceEquals(a, b);

        public override bool Equals(object? obj) => ReferenceEquals(this, obj);
        public override int GetHashCode() => Value.GetHashCode();

        public static Difficulty Parse(string value) => value.ToLower() switch
        {
            "peaceful" => Peaceful,
            "easy" => Easy,
            "normal" => Normal,
            "hard" => Hard,
            _ => throw new RedstoneException($"Unknown difficulty: {value}")
        };
    }
}
