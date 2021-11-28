using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class DrippingWater : Particle
    {
        public override VarInt Id => 13;

        public override Identifier Name => "dripping_water";
    }
}
