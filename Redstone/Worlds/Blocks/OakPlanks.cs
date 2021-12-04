using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds.Blocks
{
    public class OakPlanks : Block
    {
        public override string Name => "Oak Planks";

        public override Identifier Id => "oak_planks";

        public override int Type => 5;

        public override int Meta => 0;
    }
}
