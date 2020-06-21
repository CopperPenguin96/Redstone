using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Network.Packets
{
	public sealed class PacketHandler
	{
		public static void Write(Packet packet, object[] args)
		{
			if (args == null) throw new ArgumentNullException(nameof(args));
		}

		public static void Read(object[] args)
		{

		}
	}
}
