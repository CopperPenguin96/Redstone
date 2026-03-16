using Redstone.Core.Types;
using Redstone.Nbt.Tags;

namespace Redstone.Players.Chatting
{
    public class KeybindType : ChatComponent
    {
        public override string Type => "keybind";

        public KeybindDefinition Keybind { get; set; }

        public KeybindType(KeybindDefinition keybind)
        {
            Keybind = keybind;
        }

        public override CompoundTag Nbt
        {
            get
            {
                return new(null!)
                {
                    new StringTag("type", Type),
                    new StringTag("keybind", Keybind.Value)
                };
            }
        }
    }
}
