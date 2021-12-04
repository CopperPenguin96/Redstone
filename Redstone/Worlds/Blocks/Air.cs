using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds.Blocks
{
    public class Air : Block
    {
        public override string Name => "Air";

        public override Identifier Id => "air";

        public override int Type => 0;

        public override int Meta => 0;
    }
}
