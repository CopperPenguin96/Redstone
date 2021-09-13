using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Redstone.Network.Packets;
using Redstone.Types;
using Redstone.Worlds.Blocks;
using SmartNbt;

namespace Redstone.Network
{
	/// <summary>
	/// Class that handles the protocol and packets.
	/// </summary>
	public class Protocol
	{
		protected internal static RSACryptoServiceProvider CryptoServerProvider { get; set; }

		public static List<MinecraftClient> ConnectedClients = new();

		protected internal static RSAParameters Key { get; set; }

		public static bool AuthRequired { get; private set; }

		public static bool LibraryIit { get; private set; }

		public const int Version = 754;

		public static string ServerID;
		public static bool Init(bool requireAut, string serverIdent)
		{
			if (requireAut)
			{
				CryptoServerProvider = new RSACryptoServiceProvider(1024);
				Key = CryptoServerProvider.ExportParameters(true);
				AuthRequired = true;
			}

			ServerID = serverIdent;
			BlockRegistry.Init();
			LibraryIit = true;
			return true;
		}

		private static void InitCheck()
		{
			if (!LibraryIit)
				throw new ProtocolException("Library is not initialized.");
		}

		public static void LoginDisconnect(ref MinecraftClient, GameStream stream, string reason)
		{
			InitCheck();
			LoginDisconnect dis = new();
			dis.Send(ref ConnectedClients, stream, reason);
		}

		public static void Send(ref MinecraftClient client, GameStream stream,
			Packet packet, params object[] contents)
		{
			InitCheck();
			Send(ref client, stream, packet, contents.ToList());
		}

		public static void Send(ref MinecraftClient client, GameStream stream,
			Packet packet, object content)
		{
			InitCheck();
			Send(ref client, stream, packet, new List<object> { content });
		}

		public static void Send(ref MinecraftClient client, GameStream stream,
			Packet packet, List<object> content)
		{
			InitCheck();
			if (client == null) throw new ArgumentNullException(nameof(client));
			if (stream == null) throw new ArgumentNullException(nameof(stream));
			if (content == null) throw new ArgumentNullException(nameof(content));

			VarInt id = (byte)packet;

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
			InitCheck();
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
				case NbtFile file:
					return file.BufferSize;
			}

			throw new ProtocolException("Unknown data type");
		}
	}
}
