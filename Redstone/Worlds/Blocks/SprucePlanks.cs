using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds.Blocks
{
    public class SprucePlanks : Block
    {
        public override string Name => "Spruce Planks";

        public override Identifier Id => "spruce_planks";

        public override int Type => 5;

        public override int Meta => 1;
    }
}
