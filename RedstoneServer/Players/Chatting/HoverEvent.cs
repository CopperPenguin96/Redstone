using Redstone.Core;
using Redstone.Core.Types;
using Redstone.Nbt;
using Redstone.Nbt.Tags;

namespace Redstone.Players.Chatting
{
    public sealed class HoverEvent : ITagProvider
    {
        public HoverEventAction Action { get; }

        public Dictionary<string, HoverParameter> Parems = [];

        private HoverEvent(HoverEventAction action)
        {
            Action = action;
        }

        public static HoverEvent CreateShowText(ChatComponent value) => new(HoverEventAction.ShowText)
        {
            Parems = new Dictionary<string, HoverParameter>()
            {
                ["value"] = new HoverParameter("value", value)
            }
        };

        public static HoverEvent CreateShowItem(Identifier id, int count = 1, CompoundTag? tag = null) => new(HoverEventAction.ShowItem)
        {
            Parems = new Dictionary<string, HoverParameter>()
            {
                ["id"] = new HoverParameter("id", id),
                ["count"] = new HoverParameter("count", count),
            }
        };

        public static HoverEvent CreateShowEntity(string id, Identifier type, ChatComponent name) => new(HoverEventAction.ShowEntity)
        {
            Parems = new Dictionary<string, HoverParameter>()
            {
                ["id"] = new HoverParameter("id", id),
                ["type"] = new HoverParameter("type", type),
                ["name"] = new HoverParameter("name", name)
            }
        };

        public NbtTag Nbt
        {
            get
            {
                var tag = new CompoundTag(null!);

                switch (Action)
                {
                    case HoverEventAction.ShowText:
                        tag.Add("action", "show_text");
                        var val = Parems["value"].Value;
                        if (val is ChatComponent cc)
                        {
                            tag.Add("value", (CompoundTag)cc.Nbt);
                        }
                        else if (val is string s)
                        {
                            tag.Add("value", s);
                        }
                        else if (val is CompoundTag ct)
                        {
                            tag.Add("value", ct);
                        }
                        break;
                    case HoverEventAction.ShowItem:
                        tag.Add("action", "show_item");
                        tag.Add("id", Parems["id"].Value.ToString()!);
                        if (Parems.ContainsKey("count")) tag.Add("count", (int)Parems["count"].Value);
                        if (Parems.ContainsKey("tag") && Parems["tag"].Value is CompoundTag itemTag)
                        {
                            tag.Add("tag", itemTag);
                        }
                        break;
                    case HoverEventAction.ShowEntity:
                        tag.Add("action", "show_entity");
                        tag.Add("id", Parems["id"].Value.ToString()!);
                        tag.Add("type", Parems["type"].Value.ToString()!);
                        var nameVal = Parems["name"].Value;
                        if (nameVal is ChatComponent nc)
                        {
                            tag.Add("name", (CompoundTag)nc.Nbt);
                        }
                        else if (nameVal is string ns)
                        {
                            tag.Add("name", ns);
                        }
                        break;
                    default:
                        throw new RedstoneException("Unsupported HoverEventAction: " + Action);
                }

                return tag;
            }
        }
    }

    public struct HoverParameter(string name, object value)
    {
        public string Name { get; } = name;

        public object Value { get; set; } = value;
    }

    public enum HoverEventAction
    {
        ShowText,
        ShowItem,
        ShowEntity
    }
}
