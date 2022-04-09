using MinecraftTypes;
using Redstone.Utils;

namespace Redstone.Players
{
    public sealed class Rank
    {
        public string Name { get; set; }

        public MinecraftFormatting Color { get; set; }

        public string Prefix { get; set; }

        public short Index { get; set; }

        public bool IsHidden { get; set; }

        public Identifier Identifier { get; set; }
        
        /// <summary>
        /// Dictionary of Permissions for this rank.
        /// Key is the permission, Value is the true/false value to which
        /// if the rank has the permission.
        /// </summary>
        public Dictionary<Permission, bool> Permissions { get; set; }

        public Rank? NextRankUp { get; internal set; }

        public Rank? NextRankDown { get; internal set; }

        public Identifier? MainWorld { get; set; }

        public string FullName { get; private set; }
        
        private Rank()
        {
            Permissions = new Dictionary<Permission, bool>();
            Color = MinecraftFormatting.White;
            Prefix = "";
        }

        public Rank(string name, string id) : this()
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Identifier = id ?? throw new ArgumentNullException(nameof(id));
            FullName = Name + "#" + Identifier.Name;
        }
    }
}
