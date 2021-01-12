using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Entities;
using ProtocolSharp.Entities.Entities;
using ProtocolSharp.Network;
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

		public void Send(ref MinecraftClient client, GameStream stream, Entity entity)
		{
			if (!entity.UseWithSpawnObject)
			{
				// Todo redirect player to utilize spawn mob. Also check for painting and expierence orbs
			}
			VarInt eid = entity.EID;
			JavaUUID uniqueID = entity.UniqueID;
		}
	}
}
