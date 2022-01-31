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
    public class Blaze : Monster
    {
        public override string Name => "Blaze";

        public override VarInt Type => 6;

        internal override bool UseSpawnEntityOnly => false;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(0.6, 1.8, 0.6);

        public override Identifier Identifier => "blaze";

        private byte _blaze;

        public bool IsOnFire
        {
            get => FlagsHelper.IsSet(_blaze, (byte) BlazeFlag.OnFire);
            set
            {
                if (value) FlagsHelper.Set(ref _blaze, (byte) BlazeFlag.OnFire);
                else FlagsHelper.Unset(ref _blaze, (byte) BlazeFlag.OnFire);
            }
        }
    }
}
