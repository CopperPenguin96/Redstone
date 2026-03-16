using Redstone.Core;
using Redstone.Core.Types;
using Redstone.Nbt.Tags;

namespace Redstone.Players.Chatting
{
    public class AtlasObjectType : ChatComponent
    {
        public override string Type => "object";

        public OptValue<string> Object = new OptValue<string>();

        public OptValue<string> Atlas = new OptValue<string>();

        public string Sprite { get; set; }

        public AtlasObjectType(string sprite, string? atlas = null, string? objectName = null)
        {
            RedstoneException.ThrowIfNull(sprite);
            Sprite = sprite;

            if (atlas != null) Atlas = new OptValue<string>(atlas);

            if (objectName != null) Object = new OptValue<string>(objectName);
        }

        public override CompoundTag Nbt
        {
            get
            {
                var tag = new CompoundTag(null!)
                {
                    new StringTag("type", Type),
                    new StringTag("sprite", Sprite)
                };

                if (Object != null && Object.Enabled)
                {
                    tag.Add(new StringTag("object", Object.Value));
                }

                if (Atlas != null && Atlas.Enabled)
                {
                    tag.Add(new StringTag("atlas", Atlas.Value));
                }

                return tag;
            }
        }
    }
}
