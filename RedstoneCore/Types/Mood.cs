using Redstone.Nbt;
using Redstone.Nbt.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Core.Types
{
    public class Mood : NbtTagProvider
    {
        public int BlockSearchExtent { get; set; }

        public int Offset { get; set; }

        public SoundEvent PrimarySound { get; set; }

        public int TickDelay { get; set; }

        public override CompoundTag Nbt
        {
            get
            {
                CompoundTag moodTag = new("mood")
                {
                    { "block_search_extent", BlockSearchExtent },
                    { "offset", Offset }
                };

                return moodTag;
            }
        }

        public override void Parse(NbtTag tag)
        {
            throw new NotImplementedException();
        }
    }
}
