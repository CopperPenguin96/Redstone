using Redstone.Core.Types;
using Redstone.Nbt.Tags;

namespace Redstone.Core.Players.Chatting
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

        public override void Parse(NbtTag tag)
        {
            if (!(tag is CompoundTag compound))
                throw new ArgumentException("Expected a CompoundTag for KeybindType.");

            if (!compound.Contains("type", out NbtTag typeTag) || typeTag.ValueAsString != Type)
                throw new ArgumentException($"Expected type to be '{Type}' for KeybindType");

            if (!compound.Contains("keybind", out NbtTag keybindTag))
                throw new ArgumentException("Missing 'keybind' tag for KeybindType");

            Keybind = KeybindDefinition.Parse(keybindTag.ValueAsString);
        }
    }
}
