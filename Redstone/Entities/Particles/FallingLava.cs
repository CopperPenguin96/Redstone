using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class FallingLava : Particle
    {
        public override VarInt Id => 11;

        public override Identifier Name => "falling_lava";
    }
}
