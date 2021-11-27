using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;
using Redstone.Utils;

namespace Redstone.Network.Packets
{
    internal class Handshake : IReceivingPacket
    {
        public Packet Packet => Packet.Handshaking;
        public string Name => "Handshake";

        public void Receive(ref MinecraftClient client, GameStream stream)
        {
            VarInt protocolVersion = stream.ReadVarInt();
            string serverAddress = stream.ReadString();
            ushort port = stream.ReadShort();
            VarInt nextState = stream.ReadVarInt();
            
            if (nextState == 1)
            {
                client.State = ConnectionState.Status;
            }
            else if (nextState == 2)
            {
                client.State = ConnectionState.Login;
            }
            else
            {
                throw new Exception("Invalid Next State - Handshake");
            }
        }
    }
}
