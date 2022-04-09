using SmartBlocks.Entities.Living;

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

        private PlayerEntity _player;

        public SpawnPlayer(PlayerEntity player)
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
