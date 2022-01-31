﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Living.Mobs
{
    public class Squid : WaterAnimal
    {
        public override string Name => "Squid";

        public override VarInt Type => 86;

        internal override bool UseSpawnEntityOnly => false;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(0.8, 0.8, 0.8);

        public override Identifier Identifier => new("squid");
    }
}
