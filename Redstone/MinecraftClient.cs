using System.Net.Sockets;
using Redstone.Network;
using Redstone.Players;
using Redstone.Utils;

namespace Redstone
{ 
    public class MinecraftClient
    {
        //public Entity Entity { get; set; }

        public Player Player { get; set; }

        public string Username => Player.Username;

        public string UniqueId => Player.UniqueId.toString().Remove('-');
        
        public TcpClient Client { get; set; }
        

        internal GameStream Stream { get; set; }

        public ConnectionState State { get; set; }
        
        internal byte[] VerifyToken { get; set; }

        internal byte[] SharedToken { get; set; }

        public bool EncryptionPassed { get; set; }

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
