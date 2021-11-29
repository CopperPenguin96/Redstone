using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class ElectricSpark : Particle
    {
        public override VarInt Id => 87;

        public override Identifier Name => "electric_spark";
    }
}
