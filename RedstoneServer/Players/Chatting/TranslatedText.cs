using Redstone.Core.Types;
using Redstone.Nbt.Tags;

namespace Redstone.Players.Chatting
{
    public class TranslatedText : ChatComponent
    {
        public override string Type => "translateable";

        public string Translate { get; set; }

        public OptValue<string> Fallback = new();

        public List<TranslatedText> With = new();

        public TranslatedText(string translate, string fallback = null!, List<TranslatedText> with = null!)
        {
            Translate = translate;
            With = with;

            if (fallback == null) Fallback = new(false);
            else Fallback = new(true, fallback);
        }

        public override CompoundTag Nbt
        {
            get
            {
                CompoundTag tag = new(null!)
                {
                    new StringTag("type", Type),
                    new StringTag("translate", Translate)
                };

                if (Fallback.Enabled)
                {
                    tag.Add(new StringTag("fallback", Fallback.Value));
                }

                if (With.Count > 0)
                {
                    ListTag withList = new("with", TagType.Compound);
                    foreach (TranslatedText comp in With)
                    {
                        withList.Add(comp.Nbt);
                    }
                }

                return tag;
            }
        }
    }
}
