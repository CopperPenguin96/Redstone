using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Entities.Living.Mobs
{
    public enum MobFlag : byte
    {
        NoAi = 0x01,
        LeftHanded = 0x02,
        Aggressive = 0x04
    }
}
