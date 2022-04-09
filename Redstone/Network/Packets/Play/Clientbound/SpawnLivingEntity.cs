using Redstone.Types.Exceptions;
using SmartBlocks.Entities.Living;

namespace Redstone.Network.Packets.Play.Clientbound
{
    public class SpawnLivingEntity : ISendingPacket
    {
        public Packet Packet => Packet.SpawnLivingEntity;
        public string Name => "Spawn Living Entity";

        private LivingEntity _living;
        public SpawnLivingEntity(LivingEntity living)
        {
            if (living.UseSpawnEntityOnly ||
                living.UseSpawnXpOnly || living.UseSpawnPaintingOnly)
            {
                throw new ProtocolException("Only living entities should " +
                                            "be used in this packet.");
            }

            _living = living;
        }
        public void Send(ref MinecraftClient client, GameStream stream)
        {
            Protocol.Send(ref client, stream, Packet,
                _living.Id, _living.UniqueId.ToString(),
                _living.Type,
                _living.Position.X,
                _living.Position.Y,
                _living.Position.Z,
                _living.Position.Yaw, _living.Position.Pitch,
                _living.HeadPitch,
                (short)_living.Velocity.X,
                (short)_living.Velocity.Y, 
                (short)_living.Velocity.Z
                );
        }
    }
}
