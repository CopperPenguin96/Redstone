using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class LandingLava : Particle
    {
        public override VarInt Id => 12;

        public override Identifier Name => "landing_lava";
    }
}
