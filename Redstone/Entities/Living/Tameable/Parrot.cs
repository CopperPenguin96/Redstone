using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Living.Tameable
{
    public class Parrot : TameableAnimal
    {
        public VarInt Variant { get; set; } = 0;
    }

    public enum ParrotVariant
    {
        RedBlue = 0,
        Blue = 1,
        Green = 2,
        YellowBlue = 3,
        Grey = 4
    }
}
