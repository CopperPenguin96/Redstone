using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Entities.Living.Villagers;

namespace Redstone.Entities.Living.Monsters
{
    public class ZombieVillager : Zombie
    {
        public bool IsConverting { get; set; } = false;

        public VillagerData Data { get; set; }
            = new(VillagerType.Plains, VillagerJob.None, 1);
    }
}
