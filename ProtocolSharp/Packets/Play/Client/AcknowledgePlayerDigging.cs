using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Network;

namespace ProtocolSharp.Packets.Play.Client
{
	public class AcknowledgePlayerDigging : ISendingPacket
	{
		public Packet Packet => Packet.AcknowledgePlayerDigging;

		public string Name => "Acknowledge Player Digging";
		
		public void Send(ref MinecraftClient client, GameStream stream)
		{
			throw new NotImplementedException();
		}
	}
}
