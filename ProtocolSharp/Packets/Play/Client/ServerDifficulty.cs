using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Network;
using ProtocolSharp.Types;

namespace ProtocolSharp.Packets.Play.Client
{
    public class ServerDifficulty: ISendingPacket
    {
        public Packet Packet => Packet.ServerDifficulty;

        public string Name => "Server Difficulty";

        public void Send(ref MinecraftClient client, GameStream stream)
        {
            throw new NotImplementedException();
        }

        public void Send(ref MinecraftClient client, GameStream stream,
            Difficulty difficulty, bool locked)
        {
            Protocol.Send(ref client, stream, Packet,
                (byte) difficulty, locked);
        }
    }
}
