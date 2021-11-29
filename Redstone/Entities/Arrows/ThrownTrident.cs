using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Arrows
{
    public class ThrownTrident : AbstractArrow
    {
        /// <summary>
        /// Per enchantment
        /// </summary>
        public VarInt LoyaltyLevel { get; set; } = 0;

        public bool HasEnchantmentGlint { get; set; } = false;
    }
}
