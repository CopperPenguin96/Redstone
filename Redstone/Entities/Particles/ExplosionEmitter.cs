using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class ExplosionEmitter : Particle
    {
        public override VarInt Id => 23;

        public override Identifier Name => "explision_emitter";
    }
}
