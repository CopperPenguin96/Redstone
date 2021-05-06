using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Network;
using ProtocolSharp.Types;
using ProtocolSharp.Worlds.Blocks;

namespace ProtocolSharp.Packets.Play.Client
{
    /// <summary>
    /// Fired whenever a block is changed within the render distance.
    ///
    /// ***NOTE***: Changing a block in a chunk that is not loaded is NOT
    /// a stable action. Avoid sending block changes in unloaded chunks.
    /// </summary>
    public class BlockChange : ISendingPacket
    {
        public Packet Packet => Packet.BlockChange;

        public string Name => "Block Change";
        public void Send(ref MinecraftClient client, GameStream stream)
        {
            throw new NotImplementedException();
        }

        public void Send(ref MinecraftClient client, GameStream stream,
            Position location, Block block)
        {
            if (location == null) throw new ArgumentNullException(nameof(location));
            if (block == null) throw new ArgumentNullException(nameof(block));

            Protocol.Send(ref client, stream, Packet, location, block.NumericID);
        }
    }
}
