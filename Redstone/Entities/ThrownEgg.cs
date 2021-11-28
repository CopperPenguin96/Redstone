using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities
{
    public class ThrownEgg : Entity
    {
        public override string Name => "Thrown Egg";

        public override BoundingBox BoundingBox => new(0.25, 0.25, 0.25);

        public override Identifier Identifier => new("egg");

        /// <summary>
        /// Empty, (which behaves as if it were an egg)
        /// </summary>
        public Slot Item { get; set; }
    }
}
