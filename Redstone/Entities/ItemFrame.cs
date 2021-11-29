using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities
{
    public class ItemFrame : Entity
    {
        public Slot Item { get; set; }

        public VarInt Rotation { get; set; } = 0;
    }
}
