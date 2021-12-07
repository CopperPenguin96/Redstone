using Microsoft.VisualBasic.CompilerServices;
using Redstone.Types;
using SmartNbt.Tags;

namespace Redstone.Worlds.Blocks
{
    public partial class Spawner : Block
    {
        public override string Name => "Spawner";

        public override Identifier Id => "spawner";

        public override int Type => 52;

        public override int Meta => 0;

        /* Set data of a mob spawner (everything except for
         SpawnPotentials: current delay, min/max delay, mob 
        to be spawned, spawn count, spawn range, etc.)*/

        public short Delay { get; set; } = 0;

        public short MaxNearbyEntities { get; set; }

        public short MaxSpawnDelay { get; set; }

        public short MinSpawnDelay { get; set; }

        public short RequiredPlayerRange { get; set; }

        public short SpawnCount { get; set; }

        public short SpawnRange { get; set; }

        public NbtCompound[] SpawnData { get; set; }

        public override NbtCompound NBT
        {
            get
            {
                NbtCompound nbt = new()
                {
                    new NbtShort(DelayName, Delay),
                    new NbtShort(MaxNearbyName, MaxNearbyEntities),
                    new NbtShort(MaxSpawnName, MaxSpawnDelay),
                    new NbtShort(MinSpawnName, MinSpawnDelay),
                    new NbtShort(ReqPlRangeName, RequiredPlayerRange),
                    new NbtShort(SpawnCountName, SpawnCount),
                    new NbtCompound(SpawnDataName, SpawnData),
                    new NbtShort(SpawnRangeName, SpawnRange)
                };

                return nbt;
            }
        }

        private const string DelayName = "Delay";
        private const string MaxNearbyName = "MaxNearbyEntities";
        private const string MaxSpawnName = "MaxSpawnDelay";
        private const string MinSpawnName = "MinSpawnDelay";
        private const string ReqPlRangeName = "RequiredPlayerRange";
        private const string SpawnCountName = "SpawnCount";
        private const string SpawnDataName = "SpawnData";
        private const string SpawnRangeName = "SpawnRange";

    }
}
