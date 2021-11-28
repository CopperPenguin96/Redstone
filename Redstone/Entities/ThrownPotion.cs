using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities
{
    public class ThrownPotion : Entity
    {
        public override string Name => "Thrown Potion";

        public override BoundingBox BoundingBox => new(0.25, 0.25, 0.25);

        public override Identifier Identifier => new("potion");

        public Slot Item { get; set; }
    }
}
