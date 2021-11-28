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
        public override string Name => "Falling Block";

        public override BoundingBox BoundingBox => new(0.98, 0.98, 0.98);

        public override Identifier Identifier => new("falling_block");

        public Position SpawnPosition { get; set; } = new(0, 0, 0);
    }
}
