using fNbt;
using ProtocolSharp.Entities.Entities;
using ProtocolSharp.Network;
using ProtocolSharp.Types;

namespace ProtocolSharp.Packets.Play.Client.BlockEntityData
{
	public class SpawnerEntityData : BlockEntityData
	{ // current delay, min/max delay, mob, count, range (everything EXCEPT potentials)
		public Entity Entity { get; set; }

		public short SpawnCount { get; set; }

		public short SpawnRange { get; set; }

		public short Delay { get; set; }

		public short MinSpawnDelay { get; set; }

		public short MaxSpawnDelay { get; set; }

		public short MaxNearbyEntities { get; set; }

		public short RequiredPlayerRange { get; set; }

		public new void Send(ref MinecraftClient client, GameStream stream)
		{
			NbtCompound nbt = new NbtCompound(new NbtCompound("SpawnData",
				new[]
				{
					new NbtShort("SpawnCount", SpawnCount),
					new NbtShort("SpawnRange", SpawnRange),
					new NbtShort("Delay", Delay),
					new NbtShort("MinSpawnDelay", MinSpawnDelay),
					new NbtShort("MaxSpawnDelay", MaxSpawnDelay),
					new NbtShort("MaxNearbyEnemies", MaxNearbyEntities),
					new NbtShort("RequiredPlayerRange", RequiredPlayerRange)
				}
			));
			base.Send(ref client, stream,
				(int) BlockEntityDataAction.SetMobSpawnerData,
				nbt);
		}
	}
}
