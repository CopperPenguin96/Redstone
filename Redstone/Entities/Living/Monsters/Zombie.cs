using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Living.Monsters
{
    public class Zombie : Monster
    {
        public bool IsBaby { get; set; } = false;

        public VarInt Unused { get; set; } = 0; // Previously type

        public bool IsBecomingDrowned { get; set; } = false;
    }
}
