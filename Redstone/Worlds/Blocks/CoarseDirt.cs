using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds.Blocks
{
    public class CoarseDirt : Block
    {
        public override string Name => "Coarse Dirt";

        public override Identifier Id => "coarse_dirt";

        public override int Type => 3;

        public override int Meta => 1;
    }
}
