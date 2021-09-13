using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Configuration;
using Redstone.Utils;
using Version = Version_Management.Version;

namespace Redstone.Network.Packets.Status
{
	public class Response : ISendingPacket
	{
		public Packet Packet => Packet.Response;

		public string Name => "Response";

		public void Send(ref MinecraftClient client, GameStream stream)
		{
			ResponseData data = new()
			{
				Version = MinecraftVersion.GetResponseVersion(),
				Description = new NetworkText
				{
					text = Server.Config.GetItem<string>(ConfigCategory.Basic, "MOTD")
				},
				Players = new PlayerStatusList(),
				Icon = "data:image/png;base64," + GetIconString()
			};

			data.Save(); // Save for debug purposes
			string details = data.GetJson();
			Protocol.Send(ref client, stream, Packet.Response, details);
		}

		private static string GetIconString()
		{
			string location = Server.Config.GetItem<string>(ConfigCategory.Basic, "Icon Location").Value!;
			return location != null ? Image.FromFile(location).GetString() : "";
		}
	}
}
