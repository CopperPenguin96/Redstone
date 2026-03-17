using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Nbt
{
    public class NbtException : Exception
    {
        public NbtException() : base() { }

        public NbtException(string message) : base(message) { }

        public NbtException(string message, Exception innerException) : base(message, innerException) { }

        public NbtException(Exception innerException) : base(innerException.Message, innerException) { }
    }
}
