using System;
using Redstone.Core.Types;

namespace Redstone.Core.World
{
    /// <summary>
    /// Represents a Minecraft dimension identifier with enum-like semantics.
    /// Uses <see cref="Identifier"/> as the backing value.
    /// </summary>
    public readonly struct Dimension : IEquatable<Dimension>
    {
        public Identifier Identifier { get; }

        private Dimension(Identifier identifier)
        {
            Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
        }

        public Dimension(string name) : this(new Identifier(name)) { }

        public static readonly Dimension Overworld = new("minecraft:overworld");
        public static readonly Dimension Nether = new("minecraft:the_nether");
        public static readonly Dimension TheEnd = new("minecraft:the_end");

        public override string ToString() => Identifier?.ToString() ?? string.Empty;

        public bool Equals(Dimension other)
        {
            if (Identifier is null && other.Identifier is null) return true;
            if (Identifier is null || other.Identifier is null) return false;
            return string.Equals(Identifier.Namespace, other.Identifier.Namespace, StringComparison.Ordinal) &&
                   string.Equals(Identifier.Name, other.Identifier.Name, StringComparison.Ordinal);
        }

        public override bool Equals(object? obj) => obj is Dimension d && Equals(d);

        public override int GetHashCode()
        {
            if (Identifier is null) return 0;
            return HashCode.Combine(Identifier.Namespace, Identifier.Name);
        }

        public static implicit operator Identifier(Dimension d) => d.Identifier;

        public static implicit operator Dimension(Identifier id) => new(id);

        public static implicit operator Dimension(string name) => new(name);

        public static bool operator ==(Dimension a, Dimension b) => a.Equals(b);

        public static bool operator !=(Dimension a, Dimension b) => !a.Equals(b);
    }
}
