using System;
using ProtocolSharp.Entities;
using ProtocolSharp.Entities.Entities;
using ProtocolSharp.Network;
using ProtocolSharp.Packets.Exceptions;
using ProtocolSharp.Types;
using ProtocolSharp.Utils;

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
			throw new InvalidPacketUseException("Invalid Packet Use: Use overload with Entity");
		}

		public void Send(ref MinecraftClient client, GameStream stream, Entity entity)
		{
			if (!entity.UseWithSpawnObject)
			{
				string throwMessage = "Invalid Packet: Use {0} instead";
				string usePacket = "";
				if (entity.HasSpecialUsePacket())
				{
					switch (entity.Type)
					{
						case EntityType.Painting:
							usePacket = "Spawn Painting";
							break;
						case EntityType.ExperienceOrb:
							usePacket = "Spawn Experience Orb";
							break;
						case EntityType.PrimedExplosive:
							usePacket = "Explosion";
							break;
						case EntityType.Player:
							usePacket = "Spawn Player";
							break;
					}
				}
				else
				{
					usePacket = "Spawn Living Entity";
				}

				throwMessage = string.Format(throwMessage, usePacket);
				throw new InvalidPacketUseException(throwMessage);
			}

			VarInt eid = entity.EID;
			JavaUUID uniqueID = entity.UniqueID;
			EntityType type = entity.Type;
			double x = entity.Position.X;
			double y = entity.Position.Y;
			double z = entity.Position.Z;
			byte pitch = entity.Position.Pitch;
			byte yaw = entity.Position.Yaw;
			int data = entity.Data;
			short velX = (short) entity.Velocity.X;
			short velY = (short) entity.Velocity.Y;
			short velZ = (short) entity.Velocity.Z;

			Protocol.Send(ref client, stream, Packet,
				eid, uniqueID.ToString(), (VarInt) (int) type,
				x, y, z, pitch, yaw, data, velX, velY, velZ);
		}
	}
}
