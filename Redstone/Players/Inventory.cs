using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Players
{
    public class Inventory
    {
        public string PlayerUniqueId { get; set; }

        public string WorldUniqueId { get; set; }

        public Slot[] Slots { get; set; }

    }
}
