﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Minecarts
{
    /// <summary>
    /// Minecart with TNT
    /// </summary>
    public class ExplosiveMinecart : AbstractMinecart
    {
        public override string Name => "Minecart TNT";

        public override VarInt Type => 56;

        internal override bool UseSpawnEntityOnly => true;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(0.98, 0.7, 0.98);

        public override Identifier Identifier => new("tnt_minecart");
    }
}
