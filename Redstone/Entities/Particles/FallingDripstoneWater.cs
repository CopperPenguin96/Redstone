using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class FallingDripstoneWater : Particle
    {
        public override VarInt Id => 82;

        public override Identifier Name => "falling_dripstone_water";
    }
}
