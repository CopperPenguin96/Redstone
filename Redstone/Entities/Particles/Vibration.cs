using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class Vibration : Particle
    {
        public override VarInt Id => 37;

        public override Identifier Name => "vibration";

        /// <summary>
        /// Starting coordinates
        /// </summary>
        public PosDouble Origin { get; set; }

        /// <summary>
        /// Ending coordinates
        /// </summary>
        public PosDouble Destination { get; set; }

        public int Ticks { get; set; }
    }
}
