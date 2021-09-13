using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Network.Packets.Login
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
			ChatBuilder builder = new();
			ChatPart part = new() {Text = reason};
			builder.Add(part);
			string json = builder.
		}
	}
}
