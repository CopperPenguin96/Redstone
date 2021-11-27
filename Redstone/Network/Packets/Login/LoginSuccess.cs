using Redstone.Utils;

namespace Redstone.Network.Packets.Login
{
    internal class LoginSuccess : ISendingPacket
    {
        public Packet Packet => Packet.LoginSuccess;
        public string Name => "Login Success";

        private bool _secure = false;
        public LoginSuccess(bool secure)
        {
            _secure = secure;
        }

        public void Send(ref MinecraftClient client, GameStream stream)
        {
            string uuid = Guid.Parse(client.UniqueId).ToString();
            string username = client.Username;
            Protocol.Send(ref client, stream, Packet,
                uuid, username);

            Logger.Log($"{client.Username} has connected.");

            if (!_secure)
            {
                Logger.LogWarning($"{client.Username} has logged in while " +
                                  "the server is not secured.");
            }

            // switch state to play!
            client.State = ConnectionState.Play;
            // todo join game
        }
    }
}
