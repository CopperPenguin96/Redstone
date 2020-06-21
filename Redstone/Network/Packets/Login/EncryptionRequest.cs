using Redstone.Players;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Redstone.AppSystem;
using Redstone.AppSystem.Security;

namespace Redstone.Network.Packets.Login
{
	public class EncryptionRequest : IPacket
	{
		public Packet ID => Packet.EncryptionRequest;

		public string Name => "Encryption Request";

		public void Receive(ref Player player, GameStream stream)
		{
			throw new NotImplementedException();
		}

		public void Send(ref Player player, GameStream stream)
		{
			string serverID = Server.ID;
			byte[] verifyToken = new byte[4];
			byte[] publicKey = AsnKeyBuilder.PublicKeyToX509(Server.ServerKey).GetBytes();

			var crypto = RandomNumberGenerator.Create();
			crypto.GetBytes(verifyToken);

			player.VerifyToken = verifyToken;

			Protocol.Send(ref player, stream, Packet.EncryptionRequest,
				serverID,
				(VarInt) publicKey.Length,
				publicKey,
				(VarInt) verifyToken.Length,
				verifyToken);
		}
	}
}
