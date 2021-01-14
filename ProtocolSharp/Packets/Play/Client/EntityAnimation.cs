using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Entities.Entities;
using ProtocolSharp.Network;
using ProtocolSharp.Packets.Exceptions;

namespace ProtocolSharp.Packets.Play.Client
{
	/// <summary>
	/// Sent whenever an entity should change animation
	/// </summary>
	public class EntityAnimation : ISendingPacket
	{
		public Packet Packet => Packet.EntityAnimation;

		public string Name => "Entity Animation";
		public void Send(ref MinecraftClient client, GameStream stream)
		{
			throw new InvalidPacketUseException("Invalid Packet Use: Use overload with LivingEntity");
		}

		public void Send(ref MinecraftClient client, GameStream stream, LivingEntity ent, EntityAnimationType type)
		{
			Protocol.Send(ref client, stream, Packet,
				ent.EID, (byte) type);
		}
	}

	public enum EntityAnimationType : byte
	{
		SwingMainArm = 0,
		TakeDamage = 1,
		LeaveBed = 2,
		SwingOffhand = 3,
		CriticalEffect = 4,
		MagicCriticalEffect = 5
	}
}
