using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using java.util;
using MinecraftTypes;
using Redstone.Types;
using Redstone.Utils;
using SmartNbt.Tags;

namespace Redstone.Worlds
{
    public class Raids
    {
        public int NextAvailableId { get; set; }

        public List<Raid> RaidList { get; set; }

        public int InternalTick { get; set; }

        public NbtCompound Nbt
        {
            get
            {
                NbtList raids = new();
                foreach (Raid raid in RaidList)
                {
                    raids.Add(raid.Nbt);
                }

                NbtCompound nbt = new()
                {
                    new NbtInt("NextAvailableID", NextAvailableId),
                    raids,
                    new NbtInt("Tick", InternalTick)
                };

                return nbt;
            }
        }
    }

    public class Raid
    {
        public bool Active { get; set; }

        public int BadOmenLevel { get; set; }

        public Position RaidCenter { get; set; }

        public int GroupsSpawned { get; set; }

        public List<UUID> Heroes { get; set; }

        public int Id { get; set; }

        public int NumGroups { get; set; }

        public int PreRaidTicks { get; set; }

        public int PostRaidTicks { get; set; }

        public bool Started { get; set; }

        public string Status { get; set; }

        public TimeSpan TimeActive { get; set; }

        public float TotalHealth { get; set; }

        public NbtCompound Nbt
        {
            get
            {
                NbtList heroes = new();

                foreach (var nb in Heroes.Select(uid => new NbtCompound()
                         {
                             new NbtLong("UUIDLeast", uid.getLeastSignificantBits()),
                             new NbtLong("UUIDMost", uid.getMostSignificantBits())
                         }))
                {
                    heroes.Add(nb);
                }

                NbtCompound nbt = new()
                {
                    new NbtByte("Active", Active.ToByte()),
                    new NbtInt("BadOmenLevel", BadOmenLevel),
                    new NbtInt("CX", RaidCenter.X),
                    new NbtInt("CY", RaidCenter.Y),
                    new NbtInt("CZ", RaidCenter.Z),
                    new NbtInt("GroupsSpawned", GroupsSpawned),
                    heroes,
                    new NbtInt("Id", Id),
                    new NbtInt("NumGroups", NumGroups),
                    new NbtInt("PreRaidTicks", PreRaidTicks),
                    new NbtInt("PostRaidTicks", PostRaidTicks),
                    new NbtByte("Started", Started.ToByte()),
                    new NbtString("Status", Status),
                    new NbtLong("TicksActive", TimeActive.Ticks),
                    new NbtFloat("TotalHealth", TotalHealth)
                };
                return nbt;
            }
        }
    }
}
