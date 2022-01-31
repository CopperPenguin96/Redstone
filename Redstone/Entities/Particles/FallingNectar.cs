using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class FallingNectar : Particle
    {
        public override VarInt Id => 66;

        public override Identifier Name => "falling_nectar";
    }
}
