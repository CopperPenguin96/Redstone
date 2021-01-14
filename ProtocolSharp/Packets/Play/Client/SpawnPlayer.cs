using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Entities.Entities;
using ProtocolSharp.Network;
using ProtocolSharp.Packets.Exceptions;
using ProtocolSharp.Types;
using ProtocolSharp.Utils;

namespace ProtocolSharp.Packets.Play.Client
{
	/// <summary>
	/// This packet is sent when a player comes into visible range,
	/// NOT when a player joins.
	/// Needs to be sent after the Player Info packet.
	/// </summary>
	public class SpawnPlayer : ISendingPacket
	{

		public Packet Packet => Packet.SpawnPlayer;

		public string Name => "Spawn Player";

		public void Send(ref MinecraftClient client, GameStream stream)
		{
			throw new InvalidPacketUseException("Invalid Packet Use: Use overload with PlayerEntity");
		}

		public void Sent(ref MinecraftClient client, GameStream stream, PlayerEntity entity)
		{
			VarInt eid = entity.EID;
			JavaUUID uuid = entity.UniqueID;
			double x = entity.Position.X;
			double y = entity.Position.Y;
			double z = entity.Position.Z;
			byte yaw = entity.Position.Yaw;
			byte pitch = entity.Position.Pitch;

			Protocol.Send(ref client, stream, Packet,
				eid, uuid.ToString(), x, y, z, yaw, pitch);
		}
	}
}
