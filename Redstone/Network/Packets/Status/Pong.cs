namespace Redstone.Network.Packets.Status
{
    internal class Pong : ISendingPacket
    {
        public Packet Packet => Packet.Pong;
        public string Name => "Status Pong";

        private readonly long _ping;
        public Pong(long ping)
        {
            _ping = ping;
        }

        public void Send(ref MinecraftClient client, GameStream stream)
        {
            // Sends the ping back to the client as pong.
            // :) ping pong
            Protocol.Send(ref client, stream, Packet, _ping);
        }
    }
}
