using Redstone.Nbt;
using Redstone.Nbt.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Core.Types
{
    public class SoundEvent(Identifier id, OptValue<float> range) : NbtTagProvider
    {

        public Identifier ID { get; private set; } = id;

        public bool IsIdentificationOnly { get; private set; }

        public OptValue<bool> ReplaceDefault = new(false);

        public string Subtitle { get; set; }

        public List<Sound> Sounds { get; set; } = new();

        public override NbtTag Nbt
        {
            get
            {
                CompoundTag tag = new("sound")
                {
                    { "id", ID.ToString() }
                };

                if (range.Enabled)
                {
                    tag.Add("range", range.Value);
                }

                return tag;
            }
        }

        public override void Parse(NbtTag tag)
        {

        }
    }
}
