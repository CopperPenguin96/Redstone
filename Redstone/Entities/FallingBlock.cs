using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities
{
    public class FallingBlock : Entity
    {
        public Position SpawnPosition { get; set; } = new(0, 0, 0);

        public override string Name => "Falling Block";

        internal override bool UseSpawnEntityOnly => true;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(0.98, 0.98, 0.98);

        public override Identifier Identifier => new("falling_block");
    }
}
