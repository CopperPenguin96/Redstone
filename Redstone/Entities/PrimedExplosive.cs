﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities
{
    public class PrimedExplosive : Entity
    {
        public override string Name => "Primed TNT";

        public override VarInt Type => 69; // nice

        internal override bool UseSpawnEntityOnly => true;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(0.98, 0.98, 0.98);

        public override Identifier Identifier => new("tnt");

        public VarInt FuseTime { get; set; } = 80;
    }
}
