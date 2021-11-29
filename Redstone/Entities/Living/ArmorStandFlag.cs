using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Entities.Living
{
    public enum ArmorStandFlag : byte
    {
        Small = 0x01,
        HasArms = 0x04,
        NoBasePlate = 0x08,
        Marker = 0x10
    }
}
