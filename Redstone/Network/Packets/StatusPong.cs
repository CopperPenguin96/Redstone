using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Network.Packets
{
    internal class StatusPong : ISendingPacket
    {
        public Packet Packet => Packet.Pong;
        public string Name => "Status Pong";

        private long _ping;
        public StatusPong(long ping)
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
