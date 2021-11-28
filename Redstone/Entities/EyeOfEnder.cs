using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities
{
    public class EyeOfEnder : Entity
    {
        public override string Name => "Eye of Ender";

        public override BoundingBox BoundingBox => new(0.25, 0.25, 0.25);

        public override Identifier Identifier => new("eye_of_ender");

        public Slot Item { get; set; }
    }
}
