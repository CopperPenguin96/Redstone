using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds.Blocks
{
    public class Stone : Block
    {
        public override string Name => "Stone";

        public override Identifier Id => "stone";

        public override int Type => 1;

        public override int Meta => 0;
    }
}
