﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Living
{
    public class Goat : LivingEntity
    {
        public override string Name => "Goat";

        public override VarInt Type => 34;

        internal override bool UseSpawnEntityOnly => false;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(1.3, 0.9, 1.3);

        public override Identifier Identifier => new("goat");
    }
}
