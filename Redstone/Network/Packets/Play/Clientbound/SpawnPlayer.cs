using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Players;
using Redstone.Types.Exceptions;

namespace Redstone.Network.Packets.Play.Clientbound
{
    /// <summary>
    /// To be used when a player comes into visible range,
    /// not when a player joins.
    /// </summary>
    internal class SpawnPlayer : ISendingPacket
    {
        public Packet Packet => Packet.SpawnPlayer;
        public string Name => "Spawn Player";

        private Player _player;

        public SpawnPlayer(Player player)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
        }

        public void Send(ref MinecraftClient client, GameStream stream)
        {
            Protocol.Send(ref client, stream, Packet,
                _player.Id, _player.UniqueId,
                _player.Position.X,
                _player.Position.Y,
                _player.Position.Z,
                _player.Position.Yaw, _player.Position.Pitch);
        }
    }
}
