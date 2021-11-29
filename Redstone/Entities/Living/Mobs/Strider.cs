﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Living.Mobs
{
    public class Strider : Animal
    {
        /// <summary>
        /// Total time to "boost" with warped fungus on a stick for
        /// </summary>
        public VarInt BoostTime { get; set; } = 0;

        /// <summary>
        /// True, unless riding a vehicle or on or n a
        /// block tagged with strider_warm_blocks
        /// </summary>
        public bool IsShaking { get; set; } = false;

        public bool HasSaddle { get; set; } = false;
    }
}
