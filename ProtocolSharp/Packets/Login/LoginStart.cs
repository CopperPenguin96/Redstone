using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Network;
using ProtocolSharp.Utils;

namespace ProtocolSharp.Packets.Login
{
	public class LoginStart : IReceivingPacket
	{
		public Packet Packet => Packet.LoginStart;

		public string Name => "Login Start";

		public void Receive(ref MinecraftClient client, GameStream stream)
		{
			string username = stream.ReadString();
			client.Username = username;

			Reporting.AddReport(username + " is connecting");

			if (Protocol.AuthRequired)
			{
				new EncryptionRequest().Send(ref client, stream);
			}
			else
			{
				new LoginSuccess().Send(ref client, stream);
			}
		}
	}
}
