using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Living.Mobs
{
    public class Shulker : AbstractGolem
    {
        public Direction AttachFaceDirection { get; set; } = Direction.Down;

        public OptObject<Position> AttachmentPos { get; set; }

        public byte ShieldHeight { get; set; } = 0;

        public byte Color { get; set; } = 10;
    }
}
