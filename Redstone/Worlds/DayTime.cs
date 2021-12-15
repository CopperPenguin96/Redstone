using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Worlds
{
    public enum DayTime : long
    {
        Sunrise = 0,
        MidDay = 6000,
        Sunset = 12000,
        Midnight = 18000,
        NextDay = 24000
    }
}
