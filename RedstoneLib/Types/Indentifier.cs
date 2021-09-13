using System;

namespace Redstone.Types
{
    /// <summary>
    /// Identification system used by Minecraft
    /// ex. Stone = minecraft:stone
    /// </summary>
    public class Identifier
    {
        public string Namespace { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Namespace}:{Name}";
        }

        public Identifier(string? namespac, string name)
        {
            Namespace = namespac ?? "minecraft";
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public Identifier(string name) : this(null, name)
        {
        }
    }
}
