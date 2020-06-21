using System;
using System.Collections.Generic;
using System.Text;
using Redstone.Players;
using Redstone.Players.Chat;

namespace Redstone.Network.Packets.Login
{
	public class Disconnect : IPacket
	{
		public Packet ID => Packet.LoginDisconnect;
		public string Name => "Disconnect Login";

		public void Send(ref Player player, GameStream stream)
		{
			Send(ref player, stream, "Disconnected");
		}

		public void Send(ref Player player, GameStream stream, string reason)
		{
			ChatBuilder builder = new ChatBuilder();

			ChatPart part = new ChatPart {Text = reason};
			builder.Add(part);
			string json = builder.FullObject.ToString();

			Protocol.Send(ref player, stream, ID, json);
		}

		public void Receive(ref Player player, GameStream stream)
		{
			throw new NotImplementedException();
		}
	}
}
