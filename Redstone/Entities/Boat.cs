using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;
using Redstone.Worlds;

namespace Redstone.Entities
{
    public class Boat : Entity
    {
        public VarInt TimeSinceLastHit { get; set; } = 0;

        public VarInt ForwardDirection { get; set; } = 1;

        public float DamageTaken { get; set; } = 0.0f;

        public WoodType Type { get; set; } = WoodType.Oak;

        public bool IsLeftPaddleTurning { get; set; } = false;

        public bool IsRightPaddleTurning { get; set; } = false;

        public VarInt SplashTimer { get; set; } = 0;
    }
}
