using Redstone.Players;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using GemsCraft.Network;
using Newtonsoft.Json.Linq;
using Redstone.AppSystem;
using Redstone.AppSystem.Security;

namespace Redstone.Network.Packets.Login
{
	public class EncryptionResponse : IPacket
	{
		public Packet ID => Packet.EncryptionResponse;

		public string Name => "Encryption Response";

		private const string SessionChecker 
			= "https://sessionserver.mojang.com/session/minecraft/hasJoined?username={0}&serverId={1}";


		public void Receive(ref Player player, GameStream stream)
		{
			VarInt sharedSecretLength = stream.ReadVarInt();
			byte[] sharedSecret = stream.ReadByteArray(sharedSecretLength);

			VarInt tokenLength = stream.ReadVarInt();
			byte[] verifyToken = stream.ReadByteArray(tokenLength);

			var decryptedToken = Server.CryptoServerProvider.Decrypt(verifyToken, false);

			for (int i = 0; i < decryptedToken.Length; i++)
			{
				if (decryptedToken[i] != player.VerifyToken[i])
				{
					player.Disconnect("Unable to authenticate");
				}
			}

			player.SharedToken = Server.CryptoServerProvider.Decrypt(sharedSecret, false);
			AsnKeyBuilder.AsnMessage encodedKey = AsnKeyBuilder.PublicKeyToX509(Server.ServerKey);

			byte[] shaData = Encoding.UTF8.GetBytes(Server.ID)
				.Concat(player.SharedToken)
				.Concat(encodedKey.GetBytes()).ToArray();

			string hash = Cryptography.JavaHexDigest(shaData);

			WebClient client = new WebClient();
			StreamReader webReader = new StreamReader(client.OpenRead(
				new Uri(string.Format(SessionChecker, player.Username, hash))
				));

			string response = webReader.ReadToEnd();
			webReader.Close();

			JToken json = JToken.Parse(response);
			if (string.IsNullOrEmpty(response))
			{
				player.Disconnect("Failed to verify username.");
			}

			player.Stream = new GameStream(new AesStream(player.Stream.BaseStream, player.SharedToken));
			player.UniqueID = Guid.Parse(json["id"].Value<string>()).ToString();
			player.EncryptionEnabled = true;
			new LoginSuccess().Send(ref player, stream);
		}

		public void Send(ref Player player, GameStream stream)
		{
			throw new NotImplementedException();
		}
	}
}
