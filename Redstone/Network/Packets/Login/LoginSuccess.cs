using Redstone.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Network.Packets.Login
{
	public class LoginSuccess : IPacket
	{
		public Packet ID => Packet.LoginSuccess;

		public string Name => "Login Success";

		public void Receive(ref Player player, GameStream stream)
		{
			throw new NotImplementedException();
		}

		public void Send(ref Player player, GameStream stream)
		{
			Protocol.Send(ref player, stream, 
				ID, player.UniqueID, player.Username);
			player.State = ConnectionState.Play;
		}
	}
}
