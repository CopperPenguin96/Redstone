using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class Smoke : Particle
    {
        public override VarInt Id => 47;

        public override Identifier Name => "smoke";
    }
}
