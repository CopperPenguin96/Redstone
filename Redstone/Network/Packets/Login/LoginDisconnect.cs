using Redstone.ChatSystem;

namespace Redstone.Network.Packets.Login
{
    internal class LoginDisconnect : ISendingPacket
    {
        public Packet Packet => Packet.DisconnectLogin;
        public string Name => "Login Disconnect";

        private string _reason;
        public LoginDisconnect(string reason)
        {
            _reason = reason;
        }

        public void Send(ref MinecraftClient client, GameStream stream)
        {
            string message = Chat.Format(_reason, client.Player);
            Protocol.Send(ref client, stream, Packet, message);
        }
    }
}
