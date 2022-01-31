using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class FallingDripstoneLava : Particle
    {
        public override VarInt Id => 80;

        public override Identifier Name => "falling_dripstone_lava";
    }
}
