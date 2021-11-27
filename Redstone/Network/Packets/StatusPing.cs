using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Network.Packets
{
    /// <summary>
    /// When the client during the status phase sends a ping to the server
    /// the server responds back with the appropiate pong
    /// </summary>
    internal class StatusPing : IReceivingPacket
    {
        public Packet Packet => Packet.Ping;
        public string Name => "Status Ping";

        public void Receive(ref MinecraftClient client, GameStream stream)
        {
            long pingReceived = stream.ReadLong();
            var packet = new StatusPong(pingReceived);
            packet.Send(ref client, stream);
            client.Client.Close(); // Ensure to close so that the client can keep pinging
        }
    }
}
