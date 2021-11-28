﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class FallingWater : Particle
    {
        public override VarInt Id => 14;

        public override Identifier Name => "falling_water";
    }
}