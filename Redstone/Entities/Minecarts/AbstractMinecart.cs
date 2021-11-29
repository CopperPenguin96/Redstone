using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Minecarts
{
    public class AbstractMinecart : Entity
    {
        public VarInt ShakingPower { get; set; } = 0;

        public VarInt ShakingDirection { get; set; } = 1;

        public float ShakingMultiplier { get; set; } = 0.0f;

        public VarInt CustomBlockIdDamange { get; set; } = 0;

        public VarInt CustomBlockYPos { get; set; } = 6;

        public bool ShowCustomBlock { get; set; } = false;
    }
}
