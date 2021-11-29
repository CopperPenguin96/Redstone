using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class SmallFlame : Particle
    {
        public override VarInt Id => 77;

        public override Identifier Name => "small_flame";
    }
}
