using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds.Blocks
{
    public class Podzol : Block
    {
        public override string Name => "Podzol";

        public override Identifier Id => "podzol";

        public override int Type => 3;

        public override int Meta => 2;
    }
}
