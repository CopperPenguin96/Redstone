using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Arrows
{
    public class Arrow : AbstractArrow
    {
        /// <summary>
        /// Color, -1 for no particles
        /// </summary>
        public VarInt Color { get; set; } = -1;
    }
}
