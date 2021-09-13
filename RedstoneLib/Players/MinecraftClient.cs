using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Redstone.AppSystem;
using Redstone.Network;
using Redstone.Types;
using Redstone.Worlds.Blocks;

namespace Redstone
{
	public class MinecraftClient
	{
		public Entity? Entity { get; set; }

		public DateTime LoginTime { get; set; }

		public DateTime LastActiveTime { get; set; }

		public string Username { get; set; }

		[JsonIgnore] public bool EncryptionEnabled { get; set; }

		public string UniqueID { get; internal set; }

		[JsonIgnore] public TcpClient Client { get; set; }

		[JsonIgnore] public IPEndPoint Sender { get; set; }

		[JsonIgnore] public GameStream Stream { get; set; }

		public IPAddress IP { get; set; }

		[JsonIgnore] public ConnectionState State { get; set; }

		[JsonIgnore] public long PayLoad { get; set; }

		[JsonIgnore] internal byte[] VerifyToken { get; set; }

		[JsonIgnore] internal byte[] SharedToken { get; set; }

		public string Locale { get; set; }

		[JsonIgnore] public Position DiggingLocation { get; set; }

		[JsonIgnore] public Block BlockLookingAt { get; set; }

		[JsonIgnore] public EntityDiggingStatus DiggingStatus { get; set; }

		public void Disconnect(string reason = "Client Quit")
		{
			Logger.Log($"{Username} was disconnected. ({reason})");

			if (State == ConnectionState.Login)
			{
				MinecraftClient client = this;
				Protocol.LoginDisconnect(ref client, Stream, reason);
			}
		}

		internal MinecraftClient(TcpClient client)
		{
			Client = client;
		}

		internal MinecraftClient(TcpClient client, string username, string uuid) : this(client)
		{
			Username = username ?? throw new ArgumentNullException(nameof(username));
			UniqueID = uuid ?? throw new ArgumentNullException(nameof(uuid));
			IP = IPAddress.Loopback;
		}
	}
}
