using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Living.Mobs
{
    public class TropicalFish : AbstractFish
    {
        public override string Name => "Tropical Fish";

        internal override bool UseSpawnEntityOnly => false;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(0.5, 0.4, 0.5);

        public override Identifier Identifier => new("tropical_fish");

        public VarInt Variant { get; set; } = 0;
    }
}
