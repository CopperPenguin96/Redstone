using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class DrippingLava : Particle
    {
        public override VarInt Id => 10;

        public override Identifier Name => "dripping_lava";
    }
}
