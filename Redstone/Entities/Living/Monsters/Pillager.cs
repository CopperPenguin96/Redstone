﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Entities.Living.Monsters
{
    public class Pillager : AbstractIllager
    {
        public bool IsCharging { get; set; } = false;
    }
}