using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class CampfireSignalSmoke : Particle
    {
        public override VarInt Id => 62;

        public override Identifier Name => "campfire_signal_smoke";
    }
}
