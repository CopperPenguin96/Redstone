using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class Spit : Particle // Mojang... wanna talk about it?
    {
        public override VarInt Id => 49;

        public override Identifier Name => "spit";
    }
}
