using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Entities.Particles;
using Redstone.Types;

namespace Redstone.Entities
{
    public class AreaEffectCloud : Entity
    {
        public override string Name => "Area Effect Cloud";

        public override VarInt Type => 0;

        internal override bool UseSpawnEntityOnly => true;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(2.0, 0.5, 2.0);

        public override Identifier Identifier => "area_effect_cloud";

        // todo ? look into radius?
        public float Radius { get; set; } = 0.5f;

        /// <summary>
        /// Only for mob spell particle
        /// </summary>
        public VarInt Color { get; set; } = 0;

        /// <summary>
        /// When set to true, ignores radius and shows effect as single point, not area
        /// </summary>
        public bool IgnoreRadiusShowEffectSinglePoint { get; set; } = false;

        public Particle Particle { get; set; } = new Effect();
    }
}
