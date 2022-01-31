using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class DrippingHoney : Particle
    {
        public override VarInt Id => 63;

        public override Identifier Name => "dripping_honey";
    }
}
