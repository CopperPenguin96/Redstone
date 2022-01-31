using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class FallingSporeBlossom : Particle
    {
        public override VarInt Id => 67;

        public override Identifier Name => "falling_spore_blossom";
    }
}
