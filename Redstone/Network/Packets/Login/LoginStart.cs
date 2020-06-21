using Redstone.Players;
using System;
using System.Collections.Generic;
using System.Text;
using Redstone.AppSystem.Logging;
using Redstone.Configuration;

namespace Redstone.Network.Packets.Login
{
	public class LoginStart : IPacket
	{
		public Packet ID => Packet.LoginStart;

		public string Name => "Login Start";

		public void Receive(ref Player player, GameStream stream)
		{
			string username = stream.ReadString();
			player.Username = username;
			Logger.Log(LogType.PlayerActivity, username + " is connecting.");

			if (Config.Security.RequireAuth.Value)
			{
				new EncryptionRequest().Send(ref player, stream);
			}
			else
			{
				new LoginSuccess().Send(ref player, stream);
			}
		}

		public void Send(ref Player player, GameStream stream)
		{
			throw new NotImplementedException();
		}
	}
}
