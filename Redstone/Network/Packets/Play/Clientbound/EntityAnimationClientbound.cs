using MinecraftTypes;

namespace Redstone.Network.Packets.Play.Clientbound
{
    internal class EntityAnimationClientbound : ISendingPacket
    {
        public Packet Packet => Packet.EntityAnimationClientbound;
        public string Name => "Entity Animation (Clientbound)";

        private VarInt _id;
        private EntityAnimation _anime;

        public EntityAnimationClientbound(VarInt id, EntityAnimation anime)
        {
            _id = id;
            _anime = anime;
        }

        public void Send(ref MinecraftClient client, GameStream stream)
        {
            Protocol.Send(ref client, stream, Packet,
                _id, (byte) _anime);
        }
    }
}
