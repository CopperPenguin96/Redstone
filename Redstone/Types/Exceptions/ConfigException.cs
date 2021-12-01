using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Types.Exceptions
{
    internal class ConfigException : RedstoneException
    {
        public ConfigException(bool log = false) : base(log)
        {
        }

        public ConfigException(string message, bool log = false)
            : base(message, log)
        {
        }

        public ConfigException(string message, Exception inner, bool log = false)
            : base(message, inner, log)
        {
        }

        public ConfigException(Exception inner, bool log = false)
            : base(inner, log)
        {
        }
    }
}