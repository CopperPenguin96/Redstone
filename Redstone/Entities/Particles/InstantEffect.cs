﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Particles
{
    public class InstantEffect : Particle
    {
        public override VarInt Id => 35;

        public override Identifier Name => "instant_effect";
    }
}