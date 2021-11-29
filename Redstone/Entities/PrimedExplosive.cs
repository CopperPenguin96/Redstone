using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities
{
    public class PrimedExplosive : Entity
    {
        public VarInt FuseTime { get; set; } = 80;
    }
}
