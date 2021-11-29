using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class LandingHoney : Particle
    {
        public override VarInt Id => 65;

        public override Identifier Name => "landing_honey";
    }
}
