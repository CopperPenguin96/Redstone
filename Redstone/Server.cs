using Redstone.Players;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;
using Redstone.AppSystem;
using Redstone.AppSystem.Logging;
using Redstone.Commands;
using Redstone.Configuration;
using Redstone.Network;
using Redstone.Properties;
using Redstone.Recipes;
using Version = Redstone.AppSystem.Version;

namespace Redstone
{
	public class Server
	{
		public static long StartTime;
		public static List<Player> OnlinePlayers = new List<Player>();

		protected internal static RSACryptoServiceProvider CryptoServerProvider { get; set; }

		protected internal static RSAParameters ServerKey { get; set; }

		protected internal static string ID { get; set; }

		public static void Start()
		{
			ID = " "; 
			Console.WriteLine(Resources.ThreeDimText); // Cool ASCII Graphic :3
			Logger.Log(LogType.SystemActivity, "Starting Redstone v" + Version.App);
			Thread serverThread = new Thread(Run);
			serverThread.Start();
		}

		public static void Run()
		{
			InitServer();
			StartTime = DateTime.Now.Ticks;

			IPAddress ip = IPAddress.Parse(Config.Advanced.IPAddress.Value);
			int port = Config.General.Port.Value;
			TcpListener server = new TcpListener(ip, port);

			Logger.Log(LogType.SystemActivity, "Starting the server on " + ip + ":" + port);

			try
			{
				server.Start();
				Logger.Log("Now accepting connections.");
				while (true)
				{
					Thread tmpThread = new Thread(() =>
					{
						Player client = new Player(server.AcceptTcpClient()) {State = ConnectionState.Handshake};

						using (NetworkStream ns = client.Client.GetStream())
						{
							GameStream stream = new GameStream(ns);
							client.Stream = stream;
							using (StreamReader sr = new StreamReader(stream))
							{
								while (true)
								{
									VarInt length = stream.ReadVarInt();
									byte[] data = stream.ReadByteArray(length);
									MemoryStream ms = new MemoryStream(data);
									Protocol.Receive(ref client, new GameStream(ms));
								}
							}
						}
					});

					tmpThread.Start();
				}
			}
			catch (Exception ex)
			{
				Logger.Log(LogType.Crash, "Unable to start server! " + ex);
			}
		}

		public const string Dir = "Redstone/";

		/// <summary>
		/// Inits the server, whereby checking directories, the config, and logger.
		/// </summary>
		public static void InitServer()
		{
			// Create required directories
			if (!Directory.Exists(Dir)) Directory.CreateDirectory(Dir);
			if (!Directory.Exists(Logger.Dir)) Directory.CreateDirectory(Logger.Dir);
			if (!Directory.Exists(RecipeManager.Dir)) Directory.CreateDirectory(RecipeManager.Dir);

			if (!Config.TryLoad())
			{
				Logger.Log(LogType.Warning, "Config not loaded properly. Using defaults");
				Config.LoadDefaults();
			}

#if DEBUG

			Config.Advanced.ReducedDebugInfo.Value = false;

#endif

			Logger.Log(LogType.SystemActivity, "Loading the Logger");
			Logger.Load();

			Logger.Log(LogType.SystemActivity, "Loading the Recipe Manager");
			RecipeManager.Load();

			Logger.Log(LogType.SystemActivity, "Loading the Command Manager.");
			CommandManager.Load();

			// Encryption setup, and warning if not enabled.
			if (Config.Security.RequireAuth.Value)
			{
				CryptoServerProvider = new RSACryptoServiceProvider(1024);
				ServerKey = CryptoServerProvider.ExportParameters(true);
			}
			else
			{
				Logger.Log(LogType.Warning, "Encryption is not enabled. For max security, it is recommended you enable authentication.");
			}
		}

		public static long TimeSinceStart => DateTime.Now.Ticks - StartTime;
	}
}
