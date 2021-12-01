using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities
{
    public class FireworkRocketEntity : Entity
    {
        public override string Name => "Firework Rocket Entity";

        public override VarInt Type => 28;

        internal override bool UseSpawnEntityOnly => true;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(0.25, 0.25, 0.25);

        public override Identifier Identifier => new("firework_rocket");

        public Slot Info { get; set; }

        /// <summary>
        /// Entity ID of entity which used firework
        /// (for elytra boosting)
        /// </summary>
        public OptVarInt EntityId { get; set; }

        /// <summary>
        /// Is shot at angle from a crossbow
        /// </summary>
        public bool IsShotAtAngle { get; set; } = false;
    }
}
