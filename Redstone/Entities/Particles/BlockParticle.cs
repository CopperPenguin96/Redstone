using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class BlockParticle : Particle
    {
        public override VarInt Id => 4;

        public override Identifier Name => "block";

        public VarInt BlockState { get; set; }
    }
}
