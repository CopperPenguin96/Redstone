using Redstone.Core.Types;

namespace Redstone.Players
{
    public sealed class Player
    {
        public Guid UniqueId { get; private set; }

        public string Username { get; private set; }

        public List<PlayerProperty> Properties = new();

        public Identifier Texture { get; set; }

        public Identifier CapeTexture { get; set; }

        public Identifier ElytraTexture { get; set; }

        public Identifier Model { get; set; }

    }
}
