namespace Redstone.Types.Exceptions
{
    internal class InvalidWorldException : RedstoneException
    {
        public InvalidWorldException(bool log = false) : base(log)
        {
        }

        public InvalidWorldException(string message, bool log = false)
            : base(message, log)
        {
        }

        public InvalidWorldException(string message, Exception inner, bool log = false)
            : base(message, inner, log)
        {
        }

        public InvalidWorldException(Exception inner, bool log = false)
            : base(inner, log)
        {
        }
    }
}
