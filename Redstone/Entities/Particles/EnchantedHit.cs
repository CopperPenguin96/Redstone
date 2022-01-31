using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class EnchantedHit : Particle
    {
        public override VarInt Id => 19;

        public override Identifier Name => "enchanted_hit";
    }
}
