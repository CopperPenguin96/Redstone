namespace Redstone.Network.Packets.Status
{
    /// <summary>
    /// When the client during the status phase sends a ping to the server
    /// the server responds back with the appropiate pong
    /// </summary>
    internal class Ping : IReceivingPacket
    {
        public Packet Packet => Packet.Ping;
        public string Name => "Status Ping";

        public void Receive(ref MinecraftClient client, GameStream stream)
        {
            long pingReceived = stream.ReadLong();
            var packet = new Pong(pingReceived);
            packet.Send(ref client, stream);
            client.Client.Close(); // Ensure to close so that the client can keep pinging
        }
    }
}
