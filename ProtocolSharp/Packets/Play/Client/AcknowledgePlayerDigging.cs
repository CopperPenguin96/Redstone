using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Network;
using ProtocolSharp.Packets.Exceptions;
using ProtocolSharp.Types;
using ProtocolSharp.Worlds;
using ProtocolSharp.Worlds.Blocks;

namespace ProtocolSharp.Packets.Play.Client
{
	public class AcknowledgePlayerDigging : ISendingPacket
	{
		public Packet Packet => Packet.AcknowledgePlayerDigging;

		public string Name => "Acknowledge Player Digging";
		public void Send(ref MinecraftClient client, GameStream stream)
		{
			throw new InvalidPacketUseException("Invalid Packet Use: Use overload with BlockDigging");
		}

		public void Send(ref MinecraftClient client, GameStream stream, Block BlockDigging, bool success)
		{
			Protocol.Send(ref client, stream, Packet,
				client.DiggingLocation.GetStreamData(), BlockDigging.State, (VarInt) (int) client.DiggingStatus,
				success);
		}
	}
}
