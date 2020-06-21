using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using Redstone.AppSystem;
using Redstone.Network.Packets;
using Redstone.Network.Packets.Login;
using Redstone.Network.Packets.Play;
using Redstone.Network.Packets.Status;
using Redstone.Players;
using Version = Redstone.AppSystem.Version;

namespace Redstone.Network
{
	public class Protocol
	{
		public static Version MinecraftVersion = new Version(1, 15, 2);
		public const int Version = 578;

		public static void Receive(ref Player client, GameStream stream)
		{
			Packet vi = stream.ReadVarInt();
			switch (client.State)
			{
				case ConnectionState.Handshake:
					if (vi == Packet.Handshake) new Handshake().Receive(ref client, stream);
					break;
				case ConnectionState.Status:
					if (vi == Packet.Request) new Request().Receive(ref client, stream);
					if (vi == Packet.Ping) new Ping().Receive(ref client, stream);
					break;
				case ConnectionState.Login:
					if (vi == Packet.LoginStart) new LoginStart().Receive(ref client, stream);
					if (vi == Packet.EncryptionResponse) new EncryptionResponse().Receive(ref client, stream);
					break;
				case ConnectionState.Play:
					if (vi == Packet.ClientSettings) new ClientSettings().Receive(ref client, stream);
					break;
			}
		}

		public static void LoginDisconnect(ref Player player, GameStream stream, string reason)
		{
			Redstone.Network.Packets.Login.Disconnect dis = new Disconnect();
			dis.Send(ref player, stream, reason);
		}

		public static void Send(ref Player client, GameStream stream,
			Packet packet, params object[] contents)
		{
			Send(ref client, stream, packet, contents.ToList());
		}

		public static void Send(ref Player client, GameStream stream,
			Packet packet, object content)
		{
			Send(ref client, stream, packet, new List<object> { content });
		}

		public static void Send(ref Player client, GameStream stream,
			Packet packet, List<object> content)
		{
			if (client == null) throw new ArgumentNullException(nameof(client));
			if (stream == null) throw new ArgumentNullException(nameof(stream));
			if (content == null) throw new ArgumentNullException(nameof(content));

			VarInt id = (byte) packet;

			// Gets combined length of id + data
			VarInt length = 0;

			foreach (object o in content)
			{
				length += GetItemLength(o);
			}

			length += id.Length;

			// Write the length and id
			client.Stream.WriteVarInt(length);
			client.Stream.WriteVarInt(id);

			// Write the data
			foreach (object o in content)
			{
				client.Stream.Write(o);
			}

			// Flush it :3
			client.Stream.Flush();
		}

		private static VarInt GetItemLength(object o)
		{
			switch (o)
			{
				case bool _:
				case sbyte _:
				case byte _:
					return 1;
				case short _:
				case ushort _:
					return 2;
				case int _:
				case float _:
					return 4;
				case long _:
				case double _:
					return 8;
				case string str:
					byte[] bts = Encoding.UTF8.GetBytes(str);
					VarInt length = bts.Length;
					return length + length.Length;
				case VarInt vI:
					return vI.Length;
				case byte[] b:
					return b.Length;
			}

			throw new Exception("Unknown data type");
		}
	}


}
