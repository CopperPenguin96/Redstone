using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities
{
    public class ThrownExperienceBottle : Entity
    {
        public override string Name => "Thrown Experience Bottle";

        public override BoundingBox BoundingBox => new(0.25, 0.25, 0.25);

        public override Identifier Identifier => new("experience_bottle");

        public Slot Item { get; set; }
    }
}
