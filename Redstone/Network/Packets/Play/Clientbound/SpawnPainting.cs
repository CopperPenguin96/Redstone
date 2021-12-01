using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Entities;
using Redstone.Types;

namespace Redstone.Network.Packets.Play.Clientbound
{
    internal class SpawnPainting : ISendingPacket
    {
        public Packet Packet => Packet.SpawnPainting;
        public string Name => "Spawn Painting";

        private Position _pos;
        private int _max;

        /// <summary>
        /// Initializes the packet.
        /// </summary>
        /// <param name="pos">The top left corner where the painting will be.</param>
        /// <param name="maxAmount">The max amount of squares available</param>
        public SpawnPainting(Position pos, int maxAmount)
        {
            _pos = pos;
            _max = maxAmount;
        }

        public void Send(ref MinecraftClient client, GameStream stream)
        {
            
        }
    }
}
