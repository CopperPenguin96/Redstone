using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class EntityEffect : Particle
    {
        public override VarInt Id => 22;

        public override Identifier Name => "entity_effect";
    }
}
