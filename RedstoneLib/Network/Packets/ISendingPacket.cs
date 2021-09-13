using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Network.Packets
{
	/// <summary>
	/// Interface detailing packets sent by the server.
	/// </summary>
	public interface ISendingPacket
	{
		Packet Packet { get; }

		string Name { get; }

		void Send(ref MinecraftClient client, GameStream stream);
	}
}
