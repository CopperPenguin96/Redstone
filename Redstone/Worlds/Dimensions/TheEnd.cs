using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds.Dimensions
{
    public class TheEnd : Dimension
    {
        public override Identifier Type => "the_end";

        public override Identifier GenType => "noise";

        public override Identifier Settings => "end";
    }
}
