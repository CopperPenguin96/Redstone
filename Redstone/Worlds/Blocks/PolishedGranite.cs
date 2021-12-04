using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds.Blocks
{
    public class PolishedGranite : Block
    {
        public override string Name => "Polished Granite";

        public override Identifier Id => "polished_granite";

        public override int Type => 1;

        public override int Meta => 2;
    }
}
