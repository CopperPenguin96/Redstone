using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Entities;
using Redstone.Types;
using Redstone.Types.Exceptions;

namespace Redstone.Network.Packets.Play.Clientbound
{
    internal class SpawnEntity : ISendingPacket
    {
        public Packet Packet => Packet.SpawnEntity;
        public string Name => "Spawn Entity";

        private Entity _entity;
        public SpawnEntity(Entity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            if (!entity.AllowedSpawn || !entity.UseSpawnEntityOnly)
                throw new ProtocolException("Entity is not allowed to be passed here. " + entity.Name);

            _entity = entity;
        }

        public void Send(ref MinecraftClient client, GameStream stream)
        {
            int data = 0;
            switch (_entity.Identifier.Name)
            {
                case "item_frame":
                    ItemFrame iFrame = (ItemFrame) _entity;
                    data = iFrame.Rotation;
                    break;
                case "falling_block":
                    FallingBlock fBlock = (FallingBlock) _entity;
                    data = fBlock.World.GetAtPosition(fBlock.SpawnPosition).State;
                    break;
                case "fishing_hook":
                    FishingHook fHook = (FishingHook) _entity;
                    data = fHook.HookedId;
                    break;

            }

            Protocol.Send(ref client, stream, Packet,
                _entity.Id, _entity.UniqueId.ToString(),
                _entity.Type,
                _entity.Position.X, _entity.Position.Y, _entity.Position.Z,
                _entity.Position.Pitch, _entity.Position.Yaw,
                data,
                (short) _entity.Velocity.X,
                (short) _entity.Velocity.Y,
                (short) _entity.Velocity.Z);
        }
    }
}
