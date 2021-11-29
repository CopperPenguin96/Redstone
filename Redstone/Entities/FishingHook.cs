using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities
{
    public class FishingHook : Entity
    {
        /// <summary>
        /// Hooked entity ID + 1, or 0 if there is no hooked entity
        /// </summary>
        public VarInt HookedId { get; set; } = 0;

        public bool IsCatchable { get; set; } = false;
    }
}
