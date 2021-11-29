using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Entities.Living.Monsters
{
    public class Creeper : Monster
    {
        public CreeperState State { get; set; } = CreeperState.Idle;

        public bool IsCharged { get; set; } = false;

        public bool IsIgnited { get; set; } = false;
    }

    public enum CreeperState
    {
        Idle = -1,
        Fuse = 1
    }
}
