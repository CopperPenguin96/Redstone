using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class DrippingDripstoneWater : Particle
    {
        public override VarInt Id => 81;

        public override Identifier Name => "dripping_dripstone_water";
    }
}
