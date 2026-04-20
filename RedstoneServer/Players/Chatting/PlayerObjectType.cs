using Redstone.Core;
using Redstone.Core.Types;
using Redstone.Nbt.Tags;
using Redstone.Server;
using Redstone.Server.Players;

namespace Redstone.Core.Players.Chatting
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
                foreach (Player player in PrimaryServer.Online)
                {
                    if (player.UniqueId == PlayerID) return player;
                }

                throw new RedstoneException("Player with ID " + PlayerID + " not found.");
            }
        }

        public override NbtTag Nbt
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

        public override void Parse(NbtTag tag)
        {
            if (!(tag is CompoundTag cmp))
            {
                throw new ArgumentException("Expected CompoundTag");
            }

            // hat flag
            if (cmp.Contains("hat"))
            {
                DisplayHatLayer = cmp["hat"].ValueAsBool;
            }

            // optional object name
            if (cmp.Contains("object"))
            {
                Object = new OptValue<string>(cmp["object"].ValueAsString);
            }
            else
            {
                Object = new OptValue<string>();
            }

            // player compound with id (UUID as big-endian byte array)
            if (!cmp.Contains("player"))
            {
                throw new ArgumentException("Missing required 'player' compound");
            }

            if (!(cmp["player"] is CompoundTag playerCmp))
            {
                throw new ArgumentException("Expected 'player' to be a CompoundTag");
            }

            if (!playerCmp.Contains("id"))
            {
                throw new ArgumentException("Missing required 'id' in player compound");
            }

            var idTag = playerCmp["id"];
            if (!(idTag is ByteArrayTag btag))
            {
                throw new ArgumentException("Expected 'id' to be a ByteArrayTag");
            }

            byte[] be = btag.ValueAsByteArray;
            if (be == null || be.Length != 16)
            {
                throw new ArgumentException("Invalid player id byte array length");
            }

            // Convert from big-endian (network) UUID to .NET Guid little-endian format
            byte[] le = (byte[])be.Clone();
            Array.Reverse(le, 0, 4);
            Array.Reverse(le, 4, 2);
            Array.Reverse(le, 6, 2);

            PlayerID = new Guid(le);
        }
    }
}
