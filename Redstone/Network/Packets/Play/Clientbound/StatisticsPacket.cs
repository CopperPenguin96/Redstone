using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MinecraftTypes;
using Redstone.Statistics;
using Redstone.Types;

namespace Redstone.Network.Packets.Play.Clientbound
{
    internal class StatisticsPacket : ISendingPacket
    {
        public Packet Packet => Packet.Statistics;
        public string Name => "Statistics";

        private Statistic[] _stats;

        public StatisticsPacket(Statistic[] stats)
        {
            _stats = stats;
        }

        public void Send(ref MinecraftClient client, GameStream stream)
        {
            // manually send this packet
            VarInt id = (byte) Packet;
            VarInt length = 0;

            VarInt arrayLength = _stats.Length;
            length += arrayLength.Length;
            foreach (Statistic stat in _stats)
            {
                length += stat.Id.Length;
                length += stat.Value.Length;
                length += stat.Category.Length;
            }

            // write the packet info
            stream.WriteVarInt(length);
            stream.WriteVarInt(id);

            // Write the length
            stream.WriteVarInt(arrayLength);

            // write each item
            foreach (Statistic stat in _stats)
            {
                stream.WriteVarInt(stat.Category);
                stream.WriteVarInt(stat.Id);
                stream.WriteVarInt(stat.Value);
            }

            stream.Flush();
        }
    }
}
