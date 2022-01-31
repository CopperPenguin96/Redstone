﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Entities.Flags;
using Redstone.Types;
using Redstone.Utils;

namespace Redstone.Entities.Living.Monsters
{
    public class Spider : Monster
    {
        public override string Name => "Spider";

        public override VarInt Type => 85;

        internal override bool UseSpawnEntityOnly => false;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(1.4, 0.9, 1.4);

        public override Identifier Identifier => new("spider");

        private byte _spider = 0;

        public bool IsClimbing
        {
            get => FlagsHelper.IsSet(_spider, (byte) SpiderFlag.Climbing);
            set
            {
                if (value) FlagsHelper.Set(ref _spider, (byte) SpiderFlag.Climbing);
                else FlagsHelper.Unset(ref _spider, (byte) SpiderFlag.Climbing);
            }
        }
    }
}
