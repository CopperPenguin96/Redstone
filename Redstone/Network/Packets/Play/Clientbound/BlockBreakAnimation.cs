using MinecraftTypes;

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
                client.Player.PlayerEntity.Id, _pos, _stage);
        }
    }
}
