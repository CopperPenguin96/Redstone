using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds.Blocks
{
    public class Dirt : Block
    {
        public override string Name => "Dirt";

        public override Identifier Id => "dirt";

        public override int Type => 3;

        public override int Meta => 0;
    }
}
