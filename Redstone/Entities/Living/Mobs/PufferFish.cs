using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Living.Mobs
{
    public class PufferFish : AbstractFish
    {
        /// <summary>
        /// Varies from 0 to 2
        /// </summary>
        public VarInt PuffState { get; set; } = 0;
    }
}
