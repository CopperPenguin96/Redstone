using Redstone.Core;
using Redstone.Core.Types;
using Redstone.Nbt.Tags;

namespace Redstone.Core.Players.Chatting
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

        public override void Parse(NbtTag tag)
        {
            if (!(tag is CompoundTag compound))
                throw new RedstoneException("Expected a CompoundTag for AtlasObjectType component.");

            if (!compound.Contains("type", out NbtTag typeTag) || typeTag.ValueAsString != Type)
            {
                throw new RedstoneException($"Expected type to be '{Type}' for AtlasObjectType component.");
            }

            if (!compound.Contains("sprite", out NbtTag spriteTag))
            {
                throw new RedstoneException("Missing 'sprite' tag for AtlasObjectType component.");
            }

            Sprite = spriteTag.ValueAsString;

            if (compound.Contains("atlas", out NbtTag atlasTag))
            {
                Atlas = new OptValue<string>(atlasTag.ValueAsString);
            }

            if (compound.Contains("object", out NbtTag objectTag))
            {
                Object = new OptValue<string>(objectTag.ValueAsString);
            }
        }
    }
}
