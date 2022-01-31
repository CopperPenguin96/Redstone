using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class FallingDust : Particle
    {
        public override VarInt Id => 25;

        public override Identifier Name => "falling_dust";

        /// <summary>
        /// The ID of the block state
        /// </summary>
        public VarInt BlockState { get; set; }
    }
}
