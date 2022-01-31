using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Types.Exceptions
{
    internal class WorldNotFoundException : RedstoneException
    {
        public WorldNotFoundException(bool log = false) : base(log)
        {
        }

        public WorldNotFoundException(string message, bool log = false)
            : base(message, log)
        {
        }

        public WorldNotFoundException(string message, Exception inner, bool log = false)
            : base(message, inner, log)
        {
        }

        public WorldNotFoundException(Exception inner, bool log = false)
            : base(inner, log)
        {
        }
    }
}
