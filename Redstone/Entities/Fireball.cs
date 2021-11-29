using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities
{
    public class Fireball : Entity
    {
        public override string Name => "Fireball";

        internal override bool UseSpawnEntityOnly => true;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(1.0, 1.0, 1.0);

        public override Identifier Identifier => new("fireball");

        public Slot Item { get; set; }
    }
}
