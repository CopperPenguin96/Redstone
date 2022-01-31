using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class DamageIndicator : Particle
    {
        public override VarInt Id => 8;

        public override Identifier Name => "damage_indicator";
    }
}
