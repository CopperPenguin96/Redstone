using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Living.Monsters
{
    public class WitherSkeleton : AbstractSkeleton
    {
        public override string Name => "Wither Skeleton";

        public override VarInt Type => 103;

        internal override bool UseSpawnEntityOnly => false;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(0.7, 2.4, 0.7);

        public override Identifier Identifier => new("wither_skeleton");
    }
}
