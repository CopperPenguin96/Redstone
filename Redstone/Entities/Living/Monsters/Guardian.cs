using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Living.Monsters
{
    public class Guardian : Monster
    {
        public bool IsRetractingSpikes { get; set; } = false;

        public VarInt Target { get; set; }
    }
}
