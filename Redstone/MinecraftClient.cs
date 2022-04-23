using System.Net.Sockets;
using Redstone.Network;
using Redstone.Players;
using Redstone.Utils;

namespace Redstone
{ 
    /// <summary>
    /// The Player's Client that is connecting to the server
    /// </summary>
    public class MinecraftClient
    {
        //public Entity Entity { get; set; }

        /// <summary>
        /// The Player object
        /// </summary>
        public Player Player { get; set; }

        /// <summary>
        /// The player's username
        /// </summary>
        public string Username => Player.Username;

        /// <summary>
        /// The Unique ID (UUID) assigned to the player by Minecraft
        /// </summary>
        public string UniqueId => Player.UniqueId.toString().Remove('-');
        
        /// <summary>
        /// The TcpClient used to connect
        /// </summary>
        public TcpClient Client { get; set; }
        
        /// <summary>
        /// The stream where all connections between the player and the server take place.
        /// </summary>
        internal GameStream Stream { get; set; }

        /// <summary>
        /// The state as defined by the protocol
        /// </summary>
        public ConnectionState State { get; set; }
        
        /// <summary>
        /// Used in authenticating a client
        /// </summary>
        internal byte[] VerifyToken { get; set; }

        /// <summary>
        /// Used in authenticating a client
        /// </summary>
        internal byte[] SharedToken { get; set; }

        /// <summary>
        /// Used in authenticating a client
        /// </summary>
        public bool EncryptionPassed { get; set; }

        /// <summary>
        /// Disconnects the client with specific reason.
        /// If no reason is given, defaults to "Client Quit"
        /// </summary>
        /// <param name="reason"></param>
        public void Disconnect(string reason = "Client Quit")
        {
            Logger.Log($"{Username} was disconnected. ({reason})");
            if (State == ConnectionState.Login)
            {
                Protocol.LoginDisconnect(this, Stream, reason);
            }
            else if (State == ConnectionState.Play)
            {
                //
            }
        }

        internal MinecraftClient(TcpClient client)
        {
            Client = client;
        }
    }
}
