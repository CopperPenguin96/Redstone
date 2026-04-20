using Redstone.Core;
using Redstone.Core.Players.Chatting;
using Redstone.Core.Types;
using Redstone.Nbt.Tags;

namespace Redstone.Server.Players.Chatting
{
    public class EntityNames : ChatComponent
    {
        public override string Type => "selector";

        public Selector Selector { get; set; }

        public ChatComponent Seperator = Parse("{color: \"gray\", text:\",\"}");

        public EntityNames(Selector selector, ChatComponent seperator = null!)
        {
            RedstoneException.ThrowIfNull(selector);
            Selector = selector;
            Seperator = seperator ?? Parse("{color: \"gray\", text:\",\"}");
        }

        public override CompoundTag Nbt
        {
            get
            {
                return new(null!)
                {
                    new StringTag("type", Type),
                    new StringTag("selector", Selector.Value.ToString()),
                    new CompoundTag("separator", ((CompoundTag)Seperator.Nbt).Value)
                };
            }
        }

        public override void Parse(NbtTag tag)
        {
            if (!(tag is CompoundTag compound))
                throw new RedstoneException("Expected a CompoundTag for EntityNames component.");

            if (!compound.Contains("type", out NbtTag typeTag) || typeTag.ValueAsString != Type)
            {
                throw new RedstoneException($"Expected type to be '{Type}' for EntityNames component.");
            }

            if (!compound.Contains("selector", out NbtTag selectorTag))
            {
                throw new RedstoneException("Missing 'selector' tag for EntityNames component.");
            }

            if (!compound.Contains("separator", out NbtTag separatorTag))
            {
                throw new RedstoneException("Missing 'separator' tag for EntityNames component.");
            }

            Selector = Selector.Parse(selectorTag.ValueAsString);
            Seperator = ChatComponent.Parse((separatorTag as CompoundTag)?.ToString() ?? throw new RedstoneException("Invalid 'separator' tag for EntityNames component."));


        }
    }
}
