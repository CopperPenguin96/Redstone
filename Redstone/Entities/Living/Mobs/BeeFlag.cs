using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Entities.Living.Mobs
{
    public enum BeeFlag : byte
    {
        Unused = 0x01,
        Angry = 0x02,
        Stung = 0x04,
        Nectar = 0x08
    }
}
