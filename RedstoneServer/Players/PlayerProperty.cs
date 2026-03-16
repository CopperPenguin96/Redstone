using Redstone.Core.Types;
using Redstone.Nbt;
using Redstone.Nbt.Tags;

namespace Redstone.Players
{
    public struct PlayerProperty : ITagProvider
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public OptValue<string> Signature = new OptValue<string>();

        public PlayerProperty(string name, string value, string sign = null!)
        {
            Name = name;
            Value = value;

            if (sign == null)
            {
                Signature = new OptValue<string>();
            }
            else
            {
                Signature = new OptValue<string>(sign);
            }
        }

        public NbtTag Nbt
        {
            get
            {
                var cmp = new CompoundTag(null!)
                {
                    new StringTag("name", Name),
                    new StringTag("value", Value)
                };

                if (Signature != null && Signature.Enabled)
                {
                    cmp.Add(new StringTag("signature", Signature.Value));
                }

                return cmp;
            }
        }
    }
}
