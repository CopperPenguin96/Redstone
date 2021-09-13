using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using Redstone.AppSystem;

namespace Redstone.Security
{
	[Serializable]
    public sealed class BerDecodeException : RedstoneException
    {
	    public int Position { get; }

        public override string Message
        {
            get
            {
                StringBuilder sb = new(base.Message);

                sb.AppendFormat(" (Position {0}){1}",
                  Position, Environment.NewLine);

                return sb.ToString();
            }
        }

        public BerDecodeException()
        { }

        public BerDecodeException(string message)
            : base(message) { }

        public BerDecodeException(string message, Exception ex)
            : base(message, ex) { }

        public BerDecodeException(string message, int position)
            : base(message) { Position = position; }

        public BerDecodeException(string message, int position, Exception ex)
            : base(message, ex) { Position = position; }

#pragma warning disable 618
#pragma warning disable SYSLIB0003 // Type or member is obsolete
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
#pragma warning restore SYSLIB0003 // Type or member is obsolete
#pragma warning restore 618
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Position", Position);
        }
    }
}