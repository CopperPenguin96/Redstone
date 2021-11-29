using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Minecarts
{
    public class MinecartFurnace : AbstractMinecart
    {
        public override string Name => "Minecart Furnace";

        internal override bool UseSpawnEntityOnly => true;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(0.98, 0.7, 0.98);

        public override Identifier Identifier => new("furnace_minecart");

        public bool HasFuel { get; set; } = false;
    }
}
