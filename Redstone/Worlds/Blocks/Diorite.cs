using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Network;
using Redstone.Types;

namespace Redstone.Worlds.Blocks
{
    public class Diorite : Block
    {
        public override string Name => "Diorite";

        public override Identifier Id => "diorite";

        public override int Type => 1;

        public override int Meta => 4;
    }
}
