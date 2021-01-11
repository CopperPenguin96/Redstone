using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Network;

namespace ProtocolSharp.Packets.Play.Client
{
	/// <summary>
	/// Sent by the server when a vehicle or other non-living entity is created
	/// </summary>
	public class SpawnEntity : ISendingPacket
	{
		public Packet Packet => Packet.SpawnEntity;

		public string Name => "Spawn Entity";

		public void Send(ref MinecraftClient client, GameStream stream)
		{

		}
	}
}
