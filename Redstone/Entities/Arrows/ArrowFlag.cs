using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Entities.Arrows
{
    public enum ArrowFlag : byte
    {
        Critical = 0x01,

        /// <summary>
        /// Used by loyalty tridents when returning
        /// </summary>
        NoClip = 0x02
    }
}
