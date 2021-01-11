using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Network;
using ProtocolSharp.Utils;

namespace ProtocolSharp.Packets.Status
{
	public class Response : ISendingPacket
	{
		public Packet Packet => Packet.Response;

		public string Name => "Response";

		public void Send(ref MinecraftClient client, GameStream stream)
		{
			ResponseData data = new ResponseData
			{
				Version = MinecraftVersion.GetResponseVersion(),
				Description = new NetworkText
				{
					text = "Hello World!"
				},
				Players = new PlayerStatusList(),
				Icon = "data:image/png;base64,"
			};

			data.Save(); // Save for debug purposes
			string details = data.GetJson();
			Protocol.Send(ref client, stream, Packet.Response, details);
		}
	}
}
