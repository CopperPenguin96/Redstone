using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class Poof : Particle
    {
        public override VarInt Id => 44;

        public override Identifier Name => "poof";
    }
}
