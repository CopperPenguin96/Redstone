using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ProtocolSharp.Chat;
using ProtocolSharp.Network;

namespace ProtocolSharp.Packets.Login
{
	public sealed class LoginDisconnect : ISendingPacket
	{
		public Packet Packet => Packet.LoginDisconnect;
		public string Name => "Disconnect Login";
		public void Send(ref MinecraftClient client, GameStream stream)
		{
			Send(ref client, stream, "Disconnected");
		}

		public void Send(ref MinecraftClient client, GameStream stream, string reason)
		{
			ChatBuilder builder = new ChatBuilder();

			ChatPart part = new ChatPart {Text = reason};
			builder.Add(part);
			string json = builder.FullObject.ToString();


		}
	}
}
