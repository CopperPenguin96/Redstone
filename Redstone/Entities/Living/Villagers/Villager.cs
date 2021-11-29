﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Living.Villagers
{
    public class Villager : AbstractVillager
    {
        public override string Name => "Villager";

        internal override bool UseSpawnEntityOnly => false;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(0.6, 1.95, 0.6);

        public override Identifier Identifier => new("villager");

        public VillagerData Data { get; set; }
            = new(VillagerType.Plains, VillagerJob.None, 1);
    }
}
