﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Entities.Flags;
using Redstone.Types;
using Redstone.Utils;

namespace Redstone.Entities.Living.Mobs
{
    public class IronGolem : AbstractGolem
    {
        public override string Name => "Iron Golem";

        internal override bool UseSpawnEntityOnly => false;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(0.25, 0.25, 0.25);

        public override Identifier Identifier => new("iron_golem");

        private byte _iron = 0;

        public bool IsPlayerCreated
        {
            get => FlagsHelper.IsSet(_iron, (byte) IronGolemFlag.PlayerCreated);
            set
            {
                if (value) FlagsHelper.Set(ref _iron, (byte) IronGolemFlag.PlayerCreated);
                else FlagsHelper.Unset(ref _iron, (byte) IronGolemFlag.PlayerCreated);
            }
        }
    }
}
