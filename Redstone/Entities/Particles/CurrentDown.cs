using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class CurrentDown : Particle
    {
        public override VarInt Id => 57;

        public override Identifier Name => "current_down";
    }
}
