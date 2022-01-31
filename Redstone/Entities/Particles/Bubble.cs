using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class Bubble : Particle
    {
        public override VarInt Id => 5;

        public override Identifier Name => "bubble";
    }
}
