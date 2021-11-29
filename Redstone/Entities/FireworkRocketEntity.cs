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
