using Redstone.Types;
using Redstone.Utils;

namespace Redstone.ChatSystem
{
    public sealed class ChatBuilder
    {
        private JsonObject _builder = new();
        private List<ChatPart> _parts = new();

        public void Add(ChatPart part)
        {
            if (part == null) throw new ArgumentNullException(nameof(part));
            if (part.Text == null) throw new NullReferenceException(nameof(part.Text));

            _parts.Add(part);
        }

        /// <summary>
        /// produces the JSON string that will be the sent to the client
        /// to produce a chat message
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Identifier altFont = new("alt");
            Identifier defaultFont = new("default");
            Identifier uniformFont = new("uniform");

            _builder.Add("translate", "chat.type.text");
            JsonArray textArray = new();
            foreach (var part in _parts)
            {
                JsonObject arrayOf = new();
                arrayOf.Add("text", part.Text);
                if (part.Formatting != MinecraftFormatting.Reset)
                {
                    if (part.Formatting == MinecraftFormatting.Bold
                        || part.IsBold) arrayOf.Add("bold", true);
                    else arrayOf.Add("bold", false);

                    if (part.Formatting == MinecraftFormatting.Underline
                        || part.IsUnderlined) arrayOf.Add("underlined", true);
                    else arrayOf.Add("underlined", false);

                    if (part.Formatting == MinecraftFormatting.Italic
                        || part.IsItalics) arrayOf.Add("italic", true);
                    else arrayOf.Add("italic", false);

                    if (part.Formatting == MinecraftFormatting.Strike
                        || part.IsStriked) arrayOf.Add("strikethrough", true);
                    else arrayOf.Add("strikethrough", false);

                    if (part.Formatting == MinecraftFormatting.Magic
                        || part.IsObfuscated) arrayOf.Add("obfuscated", true);
                    else arrayOf.Add("obfuscated", false);

                    if (part.Formatting != 'l' || part.Formatting != 'n'
                                               || part.Formatting != 'o' || part.Formatting != 'k' ||
                                               part.Formatting != 'm' || part.Formatting != 'r')
                    {
                        arrayOf.Add("color", part.Formatting.Code);
                    }

                    switch (part.Font)
                    {
                        case MinecraftFont.Alt:
                            arrayOf.Add(
                                "font", altFont.ToString());
                            break;
                        case MinecraftFont.Default:
                            arrayOf.Add(
                                "font", defaultFont.ToString());
                            break;
                        case MinecraftFont.Uniform:
                            arrayOf.Add(
                                "font", uniformFont.ToString());
                            break;
                    }
                }

                textArray.Add(arrayOf);
            }

            _builder.Add("with", textArray);
            return _builder.ToString();
        }
    }

    public class ChatPart
    {
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets if the text is bold.
        /// Note: this can be overwritten by corresponding format codes
        /// in the text.
        /// </summary>
        public bool IsBold { get; set; } = false;

        /// <summary>
        /// Gets or sets if the text is italicized.
        /// Note: this can be overwritten by corresponding format codes
        /// in the text.
        /// </summary>
        public bool IsItalics { get; set; } = false;

        /// <summary>
        /// Gets or sets if the text is underlined.
        /// Note: this can be overwritten by corresponding format codes
        /// in the text.
        /// </summary>
        public bool IsUnderlined { get; set; } = false;

        /// <summary>
        /// Gets or sets if the text is striked.
        /// Note: this can be overwritten by corresponding format codes
        /// in the text.
        /// </summary>
        public bool IsStriked { get; set; } = false;

        /// <summary>
        /// Gets or sets if the text is obfuscated.
        /// Note: this can be overwritten by corresponding format codes
        /// in the text.
        /// </summary>
        public bool IsObfuscated { get; set; } = false;

        /// <summary>
        /// Gets or sets if the font.
        /// Note: this can be overwritten by corresponding format codes
        /// in the text.
        /// </summary>
        public MinecraftFont Font { get; set; } = MinecraftFont.Default;

        /// <summary>
        /// Gets or sets colors or formatting.
        /// Note: this can be overwritten by corresponding format codes
        /// in the text.
        /// </summary>
        public MinecraftFormatting Formatting { get; set; }
    }

    public enum MinecraftFont
    {
        Uniform,
        Alt,
        Default
    }
}
