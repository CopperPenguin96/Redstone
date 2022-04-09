using MinecraftTypes;
using SmartBlocks.Blocks;

namespace Redstone.Network.Packets.Play.Clientbound
{
    internal class AcknowledgePlayerDigging : ISendingPacket
    {
        public Packet Packet => Packet.AcknowledgePlayerDigging;
        public string Name => "Acknowledge Player Digging";

        private Block _block;
        private DiggingStatus _status;
        private bool _success;
        private Position _pos;

        public AcknowledgePlayerDigging(Block block, DiggingStatus status, bool successful, Position pos)
        {
            _block = block;
            _status = status;
            _success = successful;
            _pos = pos;
        }

        public void Send(ref MinecraftClient client, GameStream stream)
        {
            Protocol.Send(ref client, stream, Packet,
                _pos, _block.Hardness,
                (VarInt) (int) _status, _success);
        }
    }

    public enum DiggingStatus { Started, Cancelled, Finished }
}