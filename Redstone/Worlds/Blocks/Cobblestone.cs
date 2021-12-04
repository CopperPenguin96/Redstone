using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds.Blocks
{
    public class Cobblestone : Block
    {
        public override string Name => "Cobblestone";

        public override Identifier Id => "cobblestone";

        public override int Type => 4;

        public override int Meta => 0;
    }
}
