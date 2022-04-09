namespace Redstone.Types.Exceptions
{
    internal class ProtocolException : RedstoneException
    {
        public ProtocolException(bool log = false) : base(log)
        {
        }

        public ProtocolException(string message, bool log = false)
            : base(message, log)
        {
        }

        public ProtocolException(string message, Exception inner, bool log = false)
            : base(message, inner, log)
        {
        }

        public ProtocolException(Exception inner, bool log = false)
            : base(inner, log)
        {
        }
    }
}
