using System;
using Redstone.Configuration;
using Redstone.Players;
using Redstone.Properties;
using Redstone.Utils;
using Version = Redstone.AppSystem.Version;

namespace Redstone.Network.Packets.Status
{
	public class Response : IPacket
	{
		public Packet ID => Packet.Response;
		public string Name => "Response";

		public void Send(ref Player player, GameStream stream)
		{
			ResponseData data = new ResponseData
			{
				Version = Version.GetResponseVersion(),
				Description = new NetworkText
				{
					text = Config.General.MOTD.Value
				},
				Players = new PlayerStatusList(),
				Icon = "data:image/png;base64,"
			};

			data.Save(); // Save for debug purposes
			string details = data.GetJson();
			Protocol.Send(ref player, stream, Packet.Response, details);
		}

		public void Receive(ref Player player, GameStream stream)
		{
			throw new NotImplementedException();
		}
	}
}