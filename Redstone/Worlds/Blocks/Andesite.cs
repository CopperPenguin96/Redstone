using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds.Blocks
{
    public class Andesite : Block
    {
        public override string Name => "Andesite";

        public override Identifier Id => "andesite";

        public override int Type => 1;

        public override int Meta => 5;
    }
}
