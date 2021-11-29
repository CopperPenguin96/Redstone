﻿using Redstone.Types;

namespace Redstone.Entities.Living.Ageable
{
    public class Horse : AbstractHorse
    {
        public override string Name => "oHrse";

        internal override bool UseSpawnEntityOnly => false;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(1.39648, 1.6, 1.39648);

        public override Identifier Identifier => new("horse");

        public VarInt Variant { get; set; } = 0;
    }
}
