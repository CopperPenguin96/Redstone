using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Entities;
using Redstone.Types.Exceptions;

namespace Redstone.Network.Packets.Play.Clientbound
{
    public class SpawnExperienceOrb : ISendingPacket
    {
        public Packet Packet => Packet.SpawnExperienceOrb;
        public string Name => "Spawn Experience Orb";

        private ExperienceOrb _orb;
        public SpawnExperienceOrb(ExperienceOrb orb)
        {
            if (!orb.UseSpawnXpOnly || !orb.AllowedSpawn)
                throw new ProtocolException(nameof(orb));

            _orb = orb;
        }

        public void Send(ref MinecraftClient client, GameStream stream)
        {
            Protocol.Send(ref client, stream, Packet,
                _orb.Id,
                _orb.Position.X,
                _orb.Position.Y,
                _orb.Position.Z,
                _orb.AwardAmount);
        }
    }
}
