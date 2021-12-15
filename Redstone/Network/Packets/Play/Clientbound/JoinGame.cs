using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Entities;
using Redstone.Players;

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
