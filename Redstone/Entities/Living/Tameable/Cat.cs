﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Living.Tameable
{
    public class Cat : TameableAnimal
    {
        public VarInt Type { get; set; } = 1;

        public bool IsLying { get; set; } = false;

        public bool IsRelaxed { get; set; } = false;

        public VarInt CollarColor { get; set; } = 14;
    }

    public enum CatVariant
    {
        Tabby = 0,
        Black = 1,
        Red = 2,
        Siamese = 3,
        BritishShorthair = 4,
        Calico = 5,
        Persian = 6,
        Ragdoll = 7,
        White = 8,
        Jellie = 9,
        AllBlack = 10
    }
}