using Redstone.Core;
using Redstone.Nbt;
using Redstone.Nbt.Tags;

namespace Redstone.Core.Players.Chatting
{
    public sealed class ClickEvent : NbtTagProvider
    {
        public ClickEventAction Action { get; private set; } 

        public Dictionary<string, ClickParameter> Parems = [];

        private ClickEvent(ClickEventAction action)
        {
            Action = action; 
        }

        public static ClickEvent CreateOpenUrl(string url) => new(ClickEventAction.OpenUrl)
        {
            Parems = new Dictionary<string, ClickParameter>()
            {
                ["url"] = new ClickParameter("url", url)
            }
        };

        public static ClickEvent CreateOpenFile(string path) => new(ClickEventAction.OpenFile)
        {
            Parems = new Dictionary<string, ClickParameter>()
            {
                ["path"] = new ClickParameter("path", path)
            }
        };

        public static ClickEvent CreateRunCommand(string command) => new(ClickEventAction.RunCommand)
        {
            Parems = new Dictionary<string, ClickParameter>()
            {
                ["command"] = new ClickParameter("command", command)
            }
        };

        public static ClickEvent CreateSuggestCommand(string command) => new(ClickEventAction.SuggestCommand)
        {
            Parems = new Dictionary<string, ClickParameter>()
            {
                ["command"] = new ClickParameter("command", command)
            }
        };

        public static ClickEvent CreateChangePage(int page) => new(ClickEventAction.ChangePage)
        {
            Parems = new Dictionary<string, ClickParameter>()
            {
                ["page"] = new ClickParameter("page", page)
            }
        };

        public static ClickEvent CreateCopyToClipboard(string value) => new(ClickEventAction.CopyToClipboard)
        {
            Parems = new Dictionary<string, ClickParameter>()
            {
                ["value"] = new ClickParameter("value", value)
            }
        };

        public static ClickEvent CreateShowDialog(string dialog) => new(ClickEventAction.ShowDialog)
        {
            Parems = new Dictionary<string, ClickParameter>()
            {
                ["dialog"] = new ClickParameter("dialog", dialog)
            }
        };

        public static ClickEvent CreateShowDialog(CompoundTag dialog) => new(ClickEventAction.ShowDialog)
        {
            Parems = new Dictionary<string, ClickParameter>()
            {
                ["dialog"] = new ClickParameter("dialog", dialog)
            }
        };

        public static ClickEvent CreateCustom(string id, string? payload = null)
        {
            var clickEvent = new ClickEvent(ClickEventAction.Custom)
            {
                Parems = new Dictionary<string, ClickParameter>()
                {
                    ["id"] = new ClickParameter("id", id)
                }
            };
            if (payload != null)
            {
                clickEvent.Parems["payload"] = new ClickParameter("payload", payload);
            }
            return clickEvent;
        }

        public override void Parse(NbtTag tag)
        {
            if (!(tag is CompoundTag compoundTag))
            {
                throw new RedstoneException("Expected CompoundTag for ClickEvent, got " + tag.GetType().Name);
            }

            if (!compoundTag.Contains("action"))
            {
                throw new RedstoneException("Missing 'action' field in ClickEvent CompoundTag");
            }

            var actionStr = compoundTag["action"].ValueAsString;
            switch (actionStr.ToLower())
            {
                case "open_url":
                    Action = ClickEventAction.OpenUrl;
                    Parems = new Dictionary<string, ClickParameter>()
                    {
                        ["url"] = new ClickParameter("url", compoundTag["url"].ValueAsString)
                    };
                    break;
                case "open_file":
                    Action = ClickEventAction.OpenFile;
                    Parems = new Dictionary<string, ClickParameter>()
                    {
                        ["path"] = new ClickParameter("path", compoundTag["path"].ValueAsString)
                    };
                    break;
                case "run_command":
                    Action = ClickEventAction.RunCommand;
                    Parems = new Dictionary<string, ClickParameter>()
                    {
                        ["command"] = new ClickParameter("command", compoundTag["command"].ValueAsString)
                    };
                    break;
                case "suggest_command":
                    Action = ClickEventAction.SuggestCommand;
                    Parems = new Dictionary<string, ClickParameter>()
                    {
                        ["command"] = new ClickParameter("command", compoundTag["command"].ValueAsString)
                    };
                    break;
                case "change_page":
                    Action = ClickEventAction.ChangePage;
                    Parems = new Dictionary<string, ClickParameter>()
                    {
                        ["page"] = new ClickParameter("page", compoundTag["page"].ValueAsInt)
                    };
                    break;
                case "copy_to_clipboard":
                    Action = ClickEventAction.CopyToClipboard;
                    Parems = new Dictionary<string, ClickParameter>()
                    {
                        ["value"] = new ClickParameter("value", compoundTag["value"].ValueAsString)
                    };
                    break;
                case "show_dialog":
                    Action = ClickEventAction.ShowDialog;
                    if (!compoundTag.Contains("dialog")) throw new RedstoneException("Missing 'dialog' field for show_dialog ClickEvent");
                    var dialogTag = compoundTag["dialog"];
                    object dialogVal = dialogTag.Type == TagType.String ? (object)dialogTag.ValueAsString : dialogTag as CompoundTag ?? throw new RedstoneException("Unsupported 'dialog' tag type in ClickEvent");
                    Parems = new Dictionary<string, ClickParameter>()
                    {
                        ["dialog"] = new ClickParameter("dialog", dialogVal)
                    };
                    break;
                case "custom":
                    Action = ClickEventAction.Custom;
                    if (!compoundTag.Contains("id")) throw new RedstoneException("Missing 'id' field for custom ClickEvent");
                    Parems = new Dictionary<string, ClickParameter>()
                    {
                        ["id"] = new ClickParameter("id", compoundTag["id"].ValueAsString)
                    };
                    if (compoundTag.Contains("payload"))
                    {
                        Parems["payload"] = new ClickParameter("payload", compoundTag["payload"].ValueAsString);
                    }
                    break;
                default:
                    throw new RedstoneException("Unknown ClickEvent action: " + actionStr);
            }
        }



        public override CompoundTag Nbt
        {
            get
            {
                var tag = new CompoundTag(null!);

                switch (Action)
                {
                    case ClickEventAction.OpenUrl:
                        tag.Add("action", "open_url");
                        tag.Add("url", Parems["url"].Value.ToString()!);
                        break;
                    case ClickEventAction.OpenFile:
                        tag.Add("action", "open_file");
                        tag.Add("path", Parems["path"].Value.ToString()!);
                        break;
                    case ClickEventAction.RunCommand:
                        tag.Add("action", "run_command");
                        tag.Add("command", Parems["command"].Value.ToString()!);
                        break;
                    case ClickEventAction.SuggestCommand:
                        tag.Add("action", "suggest_command");
                        tag.Add("command", Parems["command"].Value.ToString()!);
                        break;
                    case ClickEventAction.ChangePage:
                        tag.Add("action", "change_page");
                        tag.Add("page", (int)Parems["page"].Value);
                        break;
                    case ClickEventAction.CopyToClipboard:
                        tag.Add("action", "copy_to_clipboard");
                        tag.Add("value", Parems["value"].Value.ToString()!);
                        break;
                    case ClickEventAction.ShowDialog:
                        tag.Add("action", "show_dialog");
                        var val = Parems["dialog"].Value;
                        if (val is string)
                        {
                            tag.Add("dialog", val.ToString()!);
                        }
                        else if (val is CompoundTag tag1)
                        {
                            tag.Add("dialog", tag1);
                        }
                        
                        break;
                    case ClickEventAction.Custom:
                        tag.Add("action", "custom");
                        tag.Add("id", Parems["id"].Value.ToString()!);
                        if (Parems.ContainsKey("payload"))
                        {
                            tag.Add("payload", Parems["payload"].Value.ToString()!);
                        }
                        break;
                    default:
                        throw new RedstoneException("Unsupported ClickEventAction: " + Action);
                }
                return tag;
            }
        }
    }

    public struct ClickParameter(string name, object value)
    {
        public string Name { get; } = name;

        public object Value { get; set; } = value;
    }

    public enum ClickEventAction
    {
        OpenUrl,
        OpenFile,
        RunCommand,
        SuggestCommand,
        ChangePage,
        CopyToClipboard,
        ShowDialog,
        Custom
    }
}
