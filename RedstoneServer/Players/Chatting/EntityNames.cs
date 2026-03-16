using Redstone.Core;
using Redstone.Core.Types;
using Redstone.Nbt.Tags;

namespace Redstone.Players.Chatting
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
    }
}
