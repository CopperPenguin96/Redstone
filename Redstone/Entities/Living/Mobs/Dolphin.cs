using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Living.Mobs
{
    public class Dolphin : WaterAnimal
    {
        public override string Name => "Dolphin";

        internal override bool UseSpawnEntityOnly => false;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(0.9, 0.6, 0.9);

        public override Identifier Identifier => "dolphin";

        public Position TreasurePos { get; set; } = new(0, 0, 0);

        public bool CanFindTreasure { get; set; } = false;

        public bool HasFish { get; set; } = false;
    }
}
