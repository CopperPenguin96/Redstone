using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities
{
    public class Marker : Entity
    {
        public override string Name => "Marker";

        internal override bool UseSpawnEntityOnly => false;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => false;

        public override BoundingBox BoundingBox => new(0, 0, 0);

        public override Identifier Identifier => new("marker");
    }
}
