using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities
{
    public class ThrownEnderPearl : Entity
    {
        public override string Name => "Thrown Ender Pearl";

        public override BoundingBox BoundingBox => new(0.25, 0.25, 0.25);

        public override Identifier Identifier => new("ender_pearl");

        public Slot Item { get; set; }
    }
}
