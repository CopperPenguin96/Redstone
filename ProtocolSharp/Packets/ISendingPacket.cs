using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using ProtocolSharp.Network;

namespace ProtocolSharp.Packets
{
	
	public interface ISendingPacket
	{
		Packet Packet { get; }

		string Name { get; }

		void Send(ref MinecraftClient client, GameStream stream);
	}
}
