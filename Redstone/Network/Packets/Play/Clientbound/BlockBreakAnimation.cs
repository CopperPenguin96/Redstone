using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;
using Redstone.Worlds;

namespace Redstone.Network.Packets.Play.Clientbound
{
    internal class BlockBreakAnimation : ISendingPacket
    {
        public Packet Packet => Packet.BlockBreakAnimation;
        public string Name => "Block Break Animation";

        private Position _pos;
        private byte _stage;

        public BlockBreakAnimation(Position pos, byte stage)
        {
            if (stage is < 0 or > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(stage));
            }

            _pos = pos;
            _stage = stage;
        }

        public void Send(ref MinecraftClient client, GameStream stream)
        {
            Protocol.Send(ref client, stream, Packet,
                client.Player.Id, _pos, _stage);
        }
    }
}
