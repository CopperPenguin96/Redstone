using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class Flame : Particle
    {
        public override VarInt Id => 28;

        public override Identifier Name => "flame";
    }
}
