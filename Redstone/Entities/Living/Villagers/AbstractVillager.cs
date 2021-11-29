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
    public abstract class AbstractVillager : AgeableMob
    {
        public override string Name => "Abstract Villager";

        internal override bool UseSpawnEntityOnly => false;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => false;

        /// <summary>
        /// Starts at 40, decrements each tick
        /// </summary>
        public VarInt HeadShakeTimer { get; set; } = 0;
    }
}
