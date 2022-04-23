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
        /// <summary>
        /// The main directory for Redstone.
        /// Where all configs, worlds, and other misc. files are saved.
        /// </summary>
        public const string Path = "Redstone/";

        /// <summary>
        /// Redstone's software version. (Not Minecraft)
        /// </summary>
        public static readonly Version Version = new(1, 0);

        /// <summary>
        /// The List of Players currently online, fully logged in.
        /// </summary>
        public static PlayerList Online = new();

        /// <summary>
        /// The time the server started.
        /// </summary>
        public static DateTime StartTime { get; private set; }

        /// <summary>
        /// The main server thread
        /// </summary>
        public static Thread? Thread { get; private set; }

        /// <summary>
        /// If the server is in the shutdown process
        /// </summary>
        public static bool IsShuttingDown { get; internal set; }

        /// <summary>
        /// If the server is in the restart process
        /// </summary>
        public static bool IsRestarting { get; internal set; }

        /// <summary>
        /// Starts the server
        /// </summary>
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

            // Protocol must be initiated before being used
            Protocol.Init(true, "");

            // Create directories if they don't exist.
            bool dirExist = true;
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
                dirExist = false;
            }

            // Load the config
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

            // Load the world manager
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
            
            // Run the server in the main thread
            Thread = new(Run);
            Thread.Start();
        }

        /// <summary>
        /// Runs the server. Best to not use this in the foremost thread. Create a new one to use this.
        /// </summary>
        private static void Run()
        {
            try
            {
                // Create a new thread for the logger
                Thread logThread = new Thread(Logger.Watch);
                logThread.Start();

                // Create the TCP Listener and start it
                int port = Config.Port;
                TcpListener server = new(IPAddress.Any, port);
                server.Start();

                // Get the external IP, have it displayed so the host knows
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
                        /*
                         * Packet format found at https://wiki.vg/Protocol
                         *
                         * Length First (Including size of ID, and all packet info)
                         */
                        VarInt length = stream.ReadVarInt();
                        MemoryStream ms = new(stream.ReadByteArray(length));
                        Protocol.Receive(ref client, new GameStream(ms));
                    }
                }
            }
            catch (Exception ex) // Uh oh
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unable to start the server.");
                Console.WriteLine(ex.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
