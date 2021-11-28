using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities
{
    public class Particle
    {
        public virtual VarInt Id { get; }

        public virtual Identifier Name { get; }
    }
}
