using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Entities.Entities;
using ProtocolSharp.Network;
using ProtocolSharp.Packets.Exceptions;
using ProtocolSharp.Types;

namespace ProtocolSharp.Packets.Play.Client
{
	/// <summary>
	/// Spawns one or more experience orbs
	/// </summary>
	public class SpawnExperienceOrb : ISendingPacket
	{
		public Packet Packet => Packet.SpawnExperienceOrb;

		public string Name => "Spawn Experience Orb";
		public void Send(ref MinecraftClient client, GameStream stream)
		{
			throw new InvalidPacketUseException("Invalid Packet Use: Use overload with Experience Orb");
		}

		public void Send(ref MinecraftClient client, GameStream stream, ExperienceOrb orb)
		{
			VarInt eid = orb.EID;
			double x = orb.Position.X;
			double y = orb.Position.Y;
			double z = orb.Position.Z;
			short count = orb.Count;
			Protocol.Send(ref client, stream, Packet,
				eid, x, y, z, count);
		}
	}
}
