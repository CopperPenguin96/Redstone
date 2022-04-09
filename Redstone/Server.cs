using System.Net;
using System.Net.Sockets;
using MinecraftTypes;
using Redstone.Configuration;
using Redstone.Network;
using Redstone.Players;
using Redstone.Utils;

namespace Redstone
{
    /// <summary>
    /// Core of a Redstone server. Manages startup/shutdown, online player
    /// sessions, global events, and scheduled tasks.
    /// </summary>
    public sealed class Server
    {
        
        public const string Path = "Redstone/";
        public static readonly Version Version = new Version(1, 0);

        public static PlayerList Online = new();
        public static DateTime StartTime { get; private set; }

        public static Thread? Thread { get; private set; }

        public static bool IsShuttingDown { get; internal set; }

        public static bool IsRestarting { get; internal set; }

        public static void Start()
        {
            Console.WriteLine(@"                  
  _____          _     _                   
 |  __ \        | |   | |                  
 | |__) |___  __| |___| |_ ___  _ __   ___ 
 |  _  // _ \/ _` / __| __/ _ \| '_ \ / _ \
 | | \ \  __/ (_| \__ \ || (_) | | | |  __/
 |_|  \_\___|\__,_|___/\__\___/|_| |_|\___|
  __  __ ______ __                    __   
 /_ |/_ |____  /_ |  _               / /   
  | | | |   / / | | (_)  ______     / /    
  | | | |  / /  | |     |______|   / /     
  | |_| | / /   | |  _            / /      
  |_(_)_|/_(_)  |_| (_)          /_/       
                                           ");
            Logger.Log("Starting Redstone v" + Version + "...", LogLevel.System);
            StartTime = DateTime.Now;
            Protocol.Init(true, "");

            bool dirExist = true;
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
                dirExist = false;
            }

            Logger.Log("Loading the configuration", LogLevel.System);
            try
            {
                Config.Load();

                if (!Config.EnableEncryption)
                {
                    Logger.Log(
                        "It is not recommended decision to leave off Encryption. This highly impacts the security of your server. " +
                        "It is recommended you turn this on in the configuration.", LogLevel.Warning);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Logger.Log("Loading the World Manager", LogLevel.System);
            try
            {
                //WorldManager.Load();
            }
            catch (Exception e)
            {
                Logger.LogFatal("Unable to load World Manager. Server will not start.");
                Logger.LogFatal(e.ToString());
                return;
            }
            
            
            Thread = new(Run);
            Thread.Start();
        }

        private static void Run()
        {
            try
            {
                Thread logThread = new Thread(Logger.Watch);
                logThread.Start();

                int port = Config.Port;
                TcpListener server = new(IPAddress.Any, port);
                
                server.Start();
                string externalIpString = new WebClient().DownloadString("http://ipinfo.io/ip").Replace("\\r\\n", "")
                    .Replace("\\n", "").Trim();
                Logger.Log($"Starting server on {externalIpString}:{port}.");
                Logger.Log("Now accepting connections!");
                
                while (true) // wait for connections
                {
                    MinecraftClient client = new(server.AcceptTcpClient());
                    using NetworkStream ns = client.Client.GetStream();
                    GameStream stream = new(ns);
                    client.Stream = stream;
                    using StreamReader sr = new(stream);

                    while (client.Client.Connected)
                    {
                        // Receiving Packets
                        VarInt length = stream.ReadVarInt();
                        MemoryStream ms = new(stream.ReadByteArray(length));
                        Protocol.Receive(ref client, new GameStream(ms));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unable to start the server.");
                Console.WriteLine(ex.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
