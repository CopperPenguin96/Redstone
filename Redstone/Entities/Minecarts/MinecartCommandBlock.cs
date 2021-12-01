using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Minecarts
{
    public class MinecartCommandBlock : AbstractMinecart
    {
        public override string Name => "Minecart Command Block";

        public override VarInt Type => 52;

        internal override bool UseSpawnEntityOnly => true;
        
        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(0.98, 0.7, 0.98);

        public override Identifier Identifier => new("commandblock_minecart");

        public string Command { get; set; }

        // todo public Chat LastOutput { get; set; } 
    }
}
