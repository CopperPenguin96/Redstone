using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds
{
    public class World
    {
        public Block GetAtPosition(Position pos)
        {
            if (pos == null) throw new ArgumentNullException(nameof(pos));

            return null;
        }
    }
}
