using Redstone.Core.Types;
using Redstone.Nbt;
using Redstone.Nbt.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Core.World
{
    public class Timeline : NbtTagProvider
    {
        public OptValue<int> PeriodTicks { get; set; }

        public TimeMarker Clock { get; set; }


        public override NbtTag Nbt => throw new NotImplementedException();

        public override void Parse(NbtTag tag)
        {
            throw new NotImplementedException();
        }
    }
}
