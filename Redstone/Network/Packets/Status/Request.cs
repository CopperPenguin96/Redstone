namespace Redstone.Network.Packets.Status
{
    internal class Request : IReceivingPacket
    {
        public Packet Packet => Packet.Request;
        public string Name => "Request";

        public void Receive(ref MinecraftClient client, GameStream stream)
        {
            new Response().Send(ref client, stream);
        }
    }
}
