using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities
{
    public class LeashKnot : Entity
    {
        public override string Name => "Leash Knot";

        internal override bool UseSpawnEntityOnly => true;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(0.375, 0.5, 0.375);

        public override Identifier Identifier => new("leash_knot");
    }
}
