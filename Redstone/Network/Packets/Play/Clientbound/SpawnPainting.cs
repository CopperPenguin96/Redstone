using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Entities;
using Redstone.Types;

namespace Redstone.Network.Packets.Play.Clientbound
{
    internal class SpawnPainting : ISendingPacket
    {
        public Packet Packet => Packet.SpawnPainting;
        public string Name => "Spawn Painting";

        private Painting _painting;
        private Direction _dir;

        /// <summary>
        /// Initializes the packet.
        /// </summary>
        /// <param name="pos">The top left corner where the painting will be.</param>
        /// <param name="maxAmount">The max amount of squares available</param>
        public SpawnPainting(Painting pos, Direction direction)
        {
            _painting = pos;
            _dir = direction;
        }

        public void Send(ref MinecraftClient client, GameStream stream)
        {
            int x = Math.Max(0, _painting.Width / 2 - 1);
            int y = _painting.Height / 2;

            Protocol.Send(ref client, stream, Packet,
                _painting.Id, _painting.UniqueId.ToString(),
                (VarInt) _painting.PaintingType,
                new Position(x, y, 0), _dir);
        }
    }
}
