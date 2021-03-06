﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using ProtocolSharp.Network;
using ProtocolSharp.Security;
using ProtocolSharp.Types;
using ProtocolSharp.Utils;

namespace ProtocolSharp.Packets.Login
{
	public class EncryptionResponse : IReceivingPacket
	{
		public Packet Packet => Packet.EncryptionResponse;

		public string Name => "Encryption Response";

		private const string SessionChecker
			= "https://sessionserver.mojang.com/session/minecraft/hasJoined?username={0}&serverId={1}";

		public void Receive(ref MinecraftClient client, GameStream stream)
		{
			int sharedSecretLength = (int) stream.ReadVarInt().Value;
			byte[] sharedSecret = stream.ReadByteArray(sharedSecretLength);

			int tokenLength = (int) stream.ReadVarInt().Value;
			byte[] verifyToken = stream.ReadByteArray(tokenLength);

			var decryptedToken = Protocol.CryptoServerProvider.Decrypt(verifyToken, false);

			for (int i = 0; i < decryptedToken.Length; i++)
			{
				if (decryptedToken[i] != client.VerifyToken[i])
				{
					client.Disconnect("Unable to authenticate");
					string report = client.Username + " was disconnected because they failed authentication.";
					Reporting.AddReport(report);
					return;
				}

				client.SharedToken = Protocol.CryptoServerProvider.Decrypt(sharedSecret, false);
				AsnKeyBuilder.AsnMessage encodedKey = AsnKeyBuilder.PublicKeyToX509(Protocol.Key);

				byte[] shaData = Encoding.UTF8.GetBytes(Protocol.ServerID)
					.Concat(client.SharedToken)
					.Concat(encodedKey.GetBytes()).ToArray();

				string hash = Cryptography.JavaHexDigest(shaData);

				WebClient webClient = new WebClient();
				StreamReader webReader = new StreamReader(webClient.OpenRead(
						new Uri(string.Format(SessionChecker, client.Username, hash))
					));

				string response = webReader.ReadToEnd();
				webReader.Close();
				JToken json = JToken.Parse(response);

				if (string.IsNullOrEmpty(response))
				{
					Reporting.AddReport("Failed to verify username for " + client.Username);
					client.Disconnect("Failed to verify username");
					return;
				}

				client.Stream = new GameStream(new AesStream(client.Stream.BaseStream, client.SharedToken));
				client.UniqueID = Guid.Parse(json["id"].Value<string>()).ToString();
				client.EncryptionEnabled = true;
				new LoginSuccess().Send(ref client, stream);
			}
		}
	}
}
