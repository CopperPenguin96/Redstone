using Redstone.Core;
using Redstone.Nbt.Tags;

namespace Redstone.Core.Players.Chatting
{
    public class PlainText : ChatComponent
    {
        public override string Type => "text";

        public string Text { get; set; }

        public PlainText(string text)
        {
            RedstoneException.ThrowIfNull(text);

            Text = text;
        }

        public override CompoundTag Nbt
        {
            get
            {
                return new(null!)
                {
                    new StringTag("type", Type),
                    new StringTag("text", Text)
                };
            }
        }
    }
}
