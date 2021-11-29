using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Living.Mobs
{
    public class Horse : AbstractHorse
    {
        public VarInt Variant { get; set; } = 0;
    }
}
