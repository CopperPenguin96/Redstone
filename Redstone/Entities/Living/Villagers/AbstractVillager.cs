using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Entities.Living.Ageable;
using Redstone.Entities.Living.Mobs;
using Redstone.Types;

namespace Redstone.Entities.Living.Villagers
{
    public class AbstractVillager : AgeableMob
    {
        /// <summary>
        /// Starts at 40, decrements each tick
        /// </summary>
        public VarInt HeadShakeTimer { get; set; } = 0;
    }
}
