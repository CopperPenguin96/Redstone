using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds.Blocks
{
    public class GrassBlock : Block
    {
        public override string Name => "Grass Block";

        public override Identifier Id => "grass";

        public override int Type => 2;

        public override int Meta => 0;
    }
}
