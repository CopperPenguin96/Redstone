using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;
using Redstone.Worlds;

namespace Redstone.Network.Packets.Play.Clientbound
{
    internal class AcknowledgePlayerDigging : ISendingPacket
    {
        public Packet Packet => Packet.AcknowledgePlayerDigging;
        public string Name => "Acknowledge Player Digging";

        private Block _block;
        private DiggingStatus _status;
        private bool _success;

        public AcknowledgePlayerDigging(Block block, DiggingStatus status, bool successful)
        {
            _block = block;
            _status = status;
            _success = successful;
        }

        public void Send(ref MinecraftClient client, GameStream stream)
        {
            Protocol.Send(ref client, stream, Packet,
                _block.Position, _block.State,
                (VarInt) (int) _status, _success);
        }
    }

    public enum DiggingStatus { Started, Cancelled, Finished }
}