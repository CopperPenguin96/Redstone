using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using Redstone.AppSystem.Logging;
using Redstone.Entities;
using Redstone.Network;
using Redstone.Network.Packets.Play;
using Redstone.Players.Chat;
using Redstone.Players.Events;
using Redstone.Worlds;

namespace Redstone.Players
{
	public partial class Player : Entity
	{
		public static Player Console = new Player(true);

		public bool IsConsole { get; }

		/// <summary>
		/// Time when the session started
		/// </summary>
		public DateTime LoginTime { get; private set; }

		/// <summary>
		/// Time when the player was last moving/messaging
		/// </summary>
		public DateTime LastActiveTime { get; private set; }

		/// <summary>
		/// Unformatted name associated with their account
		/// </summary>
		public string Username { get; internal set; }

		[JsonIgnore] public bool EncryptionEnabled { get; set; }

		/// <summary>
		/// UUID of the player. Used by the server to call the player
		/// </summary>
		public string UniqueID { get; internal set; }

		[JsonIgnore] public TcpClient Client { get; }

		[JsonIgnore] public IPEndPoint Sender { get; }

		[JsonIgnore] public GameStream Stream { get; internal set; }

		public IPAddress IP { get; }

		[JsonIgnore] public ConnectionState State { get; set; }

		[JsonIgnore] public long Payload { get; set; }

		[JsonIgnore] internal byte[] VerifyToken { get; set; }

		[JsonIgnore] internal byte[] SharedToken { get; set; }

		public World World { get; set; }

		public string Locale { get; internal set; }

		public byte ViewDistance { get; internal set; }

		public ChatMode ChatMode { get; internal set; }

		public bool ColorsInChat { get; internal set; }

		public List<SkinPart> DisplayedParts { get; internal set; }

		public MainHand MainHand { get; internal set; }

		public Permission[] Permissions { get; set; }

		public Rank Rank { get; set; }

		private byte _slot;
		public byte Slot
		{
			get => Slot;
			set
			{
				_slot = value;
				PlayerSlotChange?.Invoke(new PlayerSlotChangedEvent(this, value));
			}
		}

		#region Event Handlers

		public delegate void PlayerSlotChangeDelegate(PlayerSlotChangedEvent e);

		public event PlayerSlotChangeDelegate PlayerSlotChange;

		#endregion

		public void Disconnect(string reason = "Client quit")
		{
			// TODO implement based on mode
			Logger.Log(Username + $" was disconnected. ({reason})");

			if (State == ConnectionState.Login)
			{
				Player player = this;
				Protocol.LoginDisconnect(ref player, Stream, reason);
			}
		}

		internal Player(TcpClient client)
		{
			Client = client;
			RegisterEvents();
		}

		/// <summary>
		/// Only to be used in case of console
		/// </summary>
		/// <param name="isConsole"></param>
		internal Player(bool isConsole)
		{
			IsConsole = isConsole;
		}

		private void RegisterEvents()
		{
			PlayerSlotChange += PlayerChangedSlot;
		}

		private void PlayerChangedSlot(PlayerSlotChangedEvent e)
		{
			new HeldItemChange().Send(ref e.Player, Stream);
		}

		internal Player(TcpClient client, string username, string uuid)
			: this(client)
		{
			Username = username ?? throw new ArgumentNullException(nameof(username));
			UniqueID = uuid ?? throw new ArgumentNullException(nameof(uuid));
			IP = IPAddress.Loopback;
		}

		public void SendMessage(string message)
		{
			// TODO implement
		}

		public bool Can(Permission permission)
		{
			return Rank.Can(permission) || Permissions.Contains(permission);
		}
	}
}
