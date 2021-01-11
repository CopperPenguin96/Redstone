using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using ProtocolSharp.Network;
using ProtocolSharp.Security;
using ProtocolSharp.Types;

namespace ProtocolSharp.Packets.Login
{
	public sealed class EncryptionRequest : ISendingPacket
	{
		public Packet Packet => Packet.EncryptionRequest;

		public string Name => "Encryption Request";

		/// <summary>
		/// Sends the Encryption request packet.
		/// NOTE: For ID, use anything.
		/// </summary>
		/// <param name="ID"></param>
		public void Send(ref MinecraftClient client, GameStream stream)
		{
			string serverID = Protocol.ServerID;
			byte[] verifyToken = new byte[4];
			byte[] publicKey = AsnKeyBuilder.PublicKeyToX509(Protocol.Key).GetBytes();

			var crypto = RandomNumberGenerator.Create();
			crypto.GetBytes(verifyToken);

			client.VerifyToken = verifyToken;

			Protocol.Send(ref client, stream, Packet,
				serverID,
				(VarInt) publicKey.Length,
				publicKey,
				(VarInt) verifyToken.Length,
				verifyToken);

		}
	}
}
