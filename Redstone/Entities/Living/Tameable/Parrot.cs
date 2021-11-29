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
        public override string Name => "Parrot";

        internal override bool UseSpawnEntityOnly => false;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(0.5, 0.9, 0.5);

        public override Identifier Identifier => new("parrot");

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
