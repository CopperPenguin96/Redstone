using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Network.Packets.Play.Clientbound
{
    internal class SpawnEntity : ISendingPacket
    {
        public Packet Packet => Packet.SpawnEntity;
        public string Name => "Spawn Entity";
        public void Send(ref MinecraftClient client, GameStream stream)
        {
            throw new NotImplementedException();
        }
    }
}
