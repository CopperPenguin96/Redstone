using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Living.Monsters
{
    public class Wither : Monster
    {
        public override string Name => "Wither";

        internal override bool UseSpawnEntityOnly => false;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(0.9, 3.5, 0.9);

        public override Identifier Identifier => new("wither");

        public VarInt CenterHeadTarget { get; set; } = 0;

        public VarInt LeftHeadTarget { get; set; } = 0;

        public VarInt RightHeadTarget { get; set; } = 0;

        public VarInt InvulnerableTime { get; set; } = 0;
    }
}
