using Redstone.Core.Types;
using Redstone.Nbt;
using Redstone.Nbt.Tags;

namespace Redstone.Core.Players
{
    public class PlayerProperty : NbtTagProvider
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

        public override CompoundTag Nbt
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

        public override void Parse(NbtTag tag)
        {
            if (!(tag is CompoundTag cmp))
            {
                throw new ArgumentException("Expected CompoundTag");
            }

            if (!cmp.Contains("name") || !cmp.Contains("value"))
            {
                throw new ArgumentException("Missing required fields in CompoundTag");
            }

            Name = cmp["name"].ValueAsString;
            Value = cmp["value"].ValueAsString;

            if (cmp.Contains("signature"))
            {
                Signature = new OptValue<string>(cmp["signature"].ValueAsString);
            }
            else
            {
                Signature = new OptValue<string>();
            }
        }
    }
}
