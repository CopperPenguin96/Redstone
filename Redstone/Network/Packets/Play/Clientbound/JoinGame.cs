namespace Redstone.Network.Packets.Play.Clientbound
{
    internal class JoinGame : ISendingPacket
    {
        public Packet Packet => Packet.JoinGame;
        public string Name => "Join Game";
        
        public void Send(ref MinecraftClient client, GameStream stream)
        {

        }
    }
}
