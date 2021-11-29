using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class WarpedSpore : Particle
    {
        public override VarInt Id => 70;

        public override Identifier Name => "warped_spore";
    }
}
