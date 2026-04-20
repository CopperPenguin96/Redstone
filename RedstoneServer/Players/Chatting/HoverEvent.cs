using Redstone.Core;
using Redstone.Core.Types;
using Redstone.Nbt;
using Redstone.Nbt.Tags;

namespace Redstone.Core.Players.Chatting
{
    public sealed class HoverEvent : NbtTagProvider
    {
        public HoverEventAction Action { get; private set; }

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

        public override void Parse(NbtTag tag)
        {
            if (!(tag is CompoundTag compoundTag))
            {
                throw new RedstoneException("Expected CompoundTag for HoverEvent, got " + tag.GetType().Name);
            }

            if (!compoundTag.Contains("action"))
            {
                throw new RedstoneException("Missing 'action' field in HoverEvent CompoundTag");
            }

            var actionStr = compoundTag["action"].ValueAsString;
            switch (actionStr.ToLower())
            {
                case "show_text":
                    Action = HoverEventAction.ShowText;
                    if (!compoundTag.Contains("value")) throw new RedstoneException("Missing 'value' field for show_text HoverEvent");
                    var vtag = compoundTag["value"];
                    if (vtag is CompoundTag ctag)
                    {
                        // Try to parse as ChatComponent from the compound's SNBT representation
                        var comp = ChatComponent.Parse(ctag.ToString());
                        Parems = new Dictionary<string, HoverParameter>()
                        {
                            ["value"] = new HoverParameter("value", comp)
                        };
                    }
                    else if (vtag.Type == TagType.String)
                    {
                        Parems = new Dictionary<string, HoverParameter>()
                        {
                            ["value"] = new HoverParameter("value", vtag.ValueAsString)
                        };
                    }
                    else
                    {
                        throw new RedstoneException("Unsupported 'value' tag type in HoverEvent show_text");
                    }
                    break;
                case "show_item":
                    Action = HoverEventAction.ShowItem;
                    if (!compoundTag.Contains("id")) throw new RedstoneException("Missing 'id' field for show_item HoverEvent");
                    var idStr = compoundTag["id"].ValueAsString;
                    Parems = new Dictionary<string, HoverParameter>()
                    {
                        ["id"] = new HoverParameter("id", new Identifier(idStr))
                    };
                    if (compoundTag.Contains("count"))
                    {
                        Parems["count"] = new HoverParameter("count", compoundTag["count"].ValueAsInt);
                    }
                    if (compoundTag.Contains("tag") && compoundTag["tag"] is CompoundTag itemTag)
                    {
                        Parems["tag"] = new HoverParameter("tag", itemTag);
                    }
                    break;
                case "show_entity":
                    Action = HoverEventAction.ShowEntity;
                    if (!compoundTag.Contains("id")) throw new RedstoneException("Missing 'id' field for show_entity HoverEvent");
                    if (!compoundTag.Contains("type")) throw new RedstoneException("Missing 'type' field for show_entity HoverEvent");
                    var entId = compoundTag["id"].ValueAsString;
                    var entType = compoundTag["type"].ValueAsString;
                    Parems = new Dictionary<string, HoverParameter>()
                    {
                        ["id"] = new HoverParameter("id", entId),
                        ["type"] = new HoverParameter("type", new Identifier(entType))
                    };
                    if (compoundTag.Contains("name"))
                    {
                        var nameTag = compoundTag["name"];
                        if (nameTag is CompoundTag nct)
                        {
                            var nameComp = ChatComponent.Parse(nct.ToString());
                            Parems["name"] = new HoverParameter("name", nameComp);
                        }
                        else if (nameTag.Type == TagType.String)
                        {
                            Parems["name"] = new HoverParameter("name", nameTag.ValueAsString);
                        }
                        else
                        {
                            throw new RedstoneException("Unsupported 'name' tag type in HoverEvent show_entity");
                        }
                    }
                    break;
                default:
                    throw new RedstoneException("Unknown HoverEvent action: " + actionStr);
            }
        }

        public override CompoundTag Nbt
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
