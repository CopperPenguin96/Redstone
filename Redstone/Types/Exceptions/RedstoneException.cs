using Redstone.Utils;

namespace Redstone.Types.Exceptions
{
    public class RedstoneException : Exception
    {
        public LogLevel Level { get; set; } = LogLevel.Warning;

        public RedstoneException(bool log = false) 
            : base()
        {
            if (log) Logger.Log(ToString(), Level);
        }

        public RedstoneException(string message, bool log = false) 
            : base(message)
        {
            if (log) Logger.Log(ToString(), Level);
        }

        public RedstoneException(string message, Exception inner, bool log = false) 
            : base(message, inner)
        {
            if (log) Logger.Log(ToString(), Level);
        }

        public RedstoneException(Exception inner, bool log = false) 
            : base("", inner)
        {
            if (log) Logger.Log(ToString(), Level);
        }
    }
}
