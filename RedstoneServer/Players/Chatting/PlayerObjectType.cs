using Redstone.Core;
using Redstone.Core.Types;
using Redstone.Nbt.Tags;

namespace Redstone.Players.Chatting
{
    public class PlayerObjectType : ChatComponent
    {
        public override string Type => "object";

        public OptValue<string> Object = new OptValue<string>();

        public Guid PlayerID { get; set; }

        public bool DisplayHatLayer { get; set; }

        public Player PlayerObject
        {
            get
            {
                foreach (Player player in Server.Online)
                {
                    if (player.UniqueId == PlayerID) return player;
                }

                throw new RedstoneException("Player with ID " + PlayerID + " not found.");
            }
        }

        public override CompoundTag Nbt
        {
            get
            {
                ListTag properties = new("properties", TagType.Compound);

                foreach (PlayerProperty property in PlayerObject.Properties)
                {
                    properties.Add(new CompoundTag(null!, (CompoundTag) property.Nbt));
                }

                var tag = new CompoundTag(null!)
                {
                    new StringTag("type", Type),
                    new BoolTag("hat", DisplayHatLayer),
                    new CompoundTag("player")
                    {
                        new StringTag("name", PlayerObject.Username),
                        new ByteArrayTag("id", PlayerObject.UniqueId.ToByteArray(true)), // true for Big Endian
                        properties
                    }
                };

                if (Object != null && Object.Enabled)
                {
                    tag.Add(new StringTag("object", Object.Value));
                }

                return tag;
            }
        }
    }
}
