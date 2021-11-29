using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities
{
    public class Painting : Entity
    {
        public override string Name => "Painting";

        internal override bool UseSpawnEntityOnly => false;

        internal override bool UseSpawnPaintingOnly => true;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox { get; set; }

        public override Identifier Identifier => new("painting");
    }
}