using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class Sneeze : Particle
    {
        public override VarInt Id => 48;

        public override Identifier Name => "sneeze";
    }
}