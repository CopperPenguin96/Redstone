using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Network;

namespace ProtocolSharp.Packets.Login
{
	public class LoginSuccess : ISendingPacket
	{
		public Packet Packet => Packet.LoginSuccess;

		public string Name => "Login Success";

		public void Send(ref MinecraftClient client, GameStream stream)
		{
			Protocol.Send(ref client, stream,
				Packet, client.UniqueID, client.Username);
			client.State = ConnectionState.Play;
		}
	}
}
