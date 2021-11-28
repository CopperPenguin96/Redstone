using System;
using JetBrains.Annotations;

namespace Redstone.Types
{
    /// <summary>
    /// Minecraft's identifiers. Used to identify different objects and
    /// values. Example: Stone is identified by minecraft:stone
    /// </summary>
    public sealed class Identifier
    {
        /// <summary>
        /// Used to determine if this is a minecraft-vanilla item,
        /// or by a third party such as a mod.
        /// </summary>
        public string? Namespace { get; set; } = "minecraft";

        /// <summary>
        /// The name of the item, for example, stone.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the string representation of the identifier
        /// </summary>
        /// <returns>For stone returns minecraft:stone</returns>
        public override string ToString()
        {
            return $"{Namespace ?? "minecraft"}:{Name}";
        }

        /// <summary>
        /// Creates the identifier
        /// </summary>
        /// <param name="ns">The namespace, for example minecraft.
        /// If left null, will default to Minecraft</param>
        /// <param name="nm">The name of the item. Cannot be left null.</param>
        /// <exception cref="ArgumentNullException">Is thrown if Name is null.</exception>
        public Identifier(string ns, string nm)
        {
            Namespace = ns;
            Name = nm ?? throw new ArgumentNullException(nameof(nm));
        }

        /// <summary>
        /// Creates the identifier
        /// </summary>
        /// <param name="name">The name of the item. Cannot be left null.</param>
        /// <exception cref="ArgumentNullException">Is thrown if Name is null.</exception>
        public Identifier(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public static implicit operator Identifier(string name)
        {
            if (name == null) throw new NullReferenceException(nameof(name));

            return new(name);
        }
    }
}
