using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ProtocolSharp.Entities.Entities;
using ProtocolSharp.Network;
using ProtocolSharp.Packets.Exceptions;
using ProtocolSharp.Types;
using ProtocolSharp.Utils;

namespace ProtocolSharp.Packets.Play.Client
{
	/// <summary>
	/// Tells the client the location, name, and type of painting
	/// </summary>
	public class SpawnPainting : ISendingPacket
	{
		public Packet Packet => Packet.SpawnPainting;

		public string Name => "Spawn Painting";

		public void Send(ref MinecraftClient client, GameStream stream)
		{
			throw new InvalidPacketUseException("Invalid Packet Use: Use overload with Spawn Painting");
		}

		public void Send(ref MinecraftClient client, GameStream stream, Painting painting)
		{
			VarInt eid = painting.EID;
			JavaUUID uuid = painting.UniqueID;
			VarInt motive = (int) painting.Design;
			Position location = painting.Position;
			// Center painting
			location.X = Math.Max(0, painting.Width / 2 - 1);
			location.Y = painting.Height / 2;
			PaintingDirection direction = painting.Direction;

			Protocol.Send(ref client, stream, Packet,
				eid, uuid.ToString(), motive, location.GetStreamData(),
				(byte) direction);
			
		}
	}
}
