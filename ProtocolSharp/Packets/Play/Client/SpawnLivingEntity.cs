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
	/// Sent by the server when a living entity is spawned
	/// </summary>
	public class SpawnLivingEntity : ISendingPacket
	{
		public Packet Packet => Packet.SpawnLivingEntity;

		public string Name => "Spawn Living Entity";
		public void Send(ref MinecraftClient client, GameStream stream)
		{
			throw new InvalidPacketUseException("Invalid Packet Use: Use overload with LivingEntity");
		}

		public void Send(ref MinecraftClient client, GameStream stream, LivingEntity ent)
		{
			VarInt eid = ent.EID;
			JavaUUID uuid = ent.UniqueID;
			VarInt type = (VarInt) (int) ent.Type;
			double x = ent.Position.X;
			double y = ent.Position.Y;
			double z = ent.Position.Z;
			double yaw = ent.Position.Yaw;
			double pitch = ent.Position.Pitch;
			double headPitch = ent.HeadPitch;
			short velX = (short) ent.Velocity.X;
			short velY = (short) ent.Velocity.Y;
			short velZ = (short) ent.Velocity.Z;

			Protocol.Send(ref client, stream, Packet,
				eid, uuid.ToString(), type, x, y, z,
				yaw, pitch, headPitch, velX, velY, velZ);
		}
	}
}
