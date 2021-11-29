﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Entities.Living.Villagers
{
    public class Villager : AbstractVillager
    {
        public VillagerData Data { get; set; }
            = new(VillagerType.Plains, VillagerJob.None, 1);
    }
}
