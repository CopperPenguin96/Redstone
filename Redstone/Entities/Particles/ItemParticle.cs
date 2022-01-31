using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class ItemParticle : Particle
    {
        public override VarInt Id => 36;

        public override Identifier Name => "item";

        /// <summary>
        /// The item that will be used
        /// </summary>
        public Slot Item { get; set; }
    }
}
