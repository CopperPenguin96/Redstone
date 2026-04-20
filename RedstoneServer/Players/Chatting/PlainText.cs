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

        public override void Parse(NbtTag tag)
        {
            if (!(tag is CompoundTag cmp)) throw new RedstoneException("Expected CompoundTag for PlainText component.");

            if (!cmp.Contains("type", out var typeTag) || typeTag.ValueAsString != Type)
                throw new RedstoneException($"Expected type '{Type}' for PlainText component, but got '{typeTag?.ValueAsString ?? "null"}'.");

            if (!cmp.Contains("text", out var textTag))
                throw new RedstoneException("Missing 'text' field for PlainText component.");

            Text = textTag.ValueAsString;
        }
    }
}
