using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Entities.Living.Mobs
{
    public enum HorseFlag : byte
    {
        Unused = 0x01,
        Tame = 0x02,
        Saddled = 0x04,
        Bred = 0x08,
        Eating = 0x10,
        Rearing = 0x20,
        MouthOpen = 0x40,
        Unused2 = 0x80
    }
}
