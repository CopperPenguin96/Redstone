﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Statistics
{
    public class Statistic
    {
        public VarInt Category { get; set; }

        public VarInt Id { get; set; }

        public VarInt Value { get; set; }

        public Statistic(StatCategory category, StatItems item, VarInt value = null!)
        {
            if (value == null!) value = 0;

            Category = (int) category;
            Id = (int) item;
            Value = value;
        }
    }
}
