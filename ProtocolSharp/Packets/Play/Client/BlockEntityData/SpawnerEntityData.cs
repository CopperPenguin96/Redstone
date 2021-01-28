using System;
using System.Collections.Generic;
using fNbt;
using ProtocolSharp.Entities.Entities;
using ProtocolSharp.Network;
using ProtocolSharp.Types;
using ProtocolSharp.Worlds.Blocks;

namespace ProtocolSharp.Packets.Play.Client.BlockEntityData
{
	public class SpawnerEntityData : BlockEntityData
	{ // current delay, min/max delay, mob, count, range (everything EXCEPT potentials)
		public Entity PotentialEntity => (Entity) ParentBlock[SpawnCountName];

		public int PotentialEntityWeight => (int) ParentBlock[WeightName];

		public short SpawnCount => (short) ParentBlock[SpawnCountName];

		public short SpawnRange => (short) ParentBlock[SpawnRangeName];

		public short Delay => (short) ParentBlock[DelayName];

		public short MinSpawnDelay => (short) ParentBlock[MinSpawnName];

		public short MaxSpawnDelay => (short) ParentBlock[MaxSpawnName];

		public short MaxNearbyEntities => (short) ParentBlock[MaxNearbyEntitiesName];

		public short RequiredPlayerRange => (short) ParentBlock[RequiredPlayerName];

		public new void Send(ref MinecraftClient client, GameStream stream)
		{
			List<NbtTag> tagsToSend = new List<NbtTag>();
			// Determine whether to send SpawnPotentials or SpawnData
			if (PotentialEntity == Entity.Basic) // Blank Potential Entity, send SpawnData
			{
				if (MinSpawnDelay > 0) // Requires Min Spawn Delay to be set
					tagsToSend.Add(new NbtShort(SpawnCountName, SpawnCount));

				tagsToSend.Add(new NbtShort(SpawnRangeName, SpawnRange));
				tagsToSend.Add(new NbtShort(DelayName, Delay));

				tagsToSend.Add(SpawnCount == 0
					? new NbtShort(MinSpawnName, 0)
					: new NbtShort(MinSpawnName, MinSpawnDelay));

				if (SpawnCount > 0 && MinSpawnDelay > 0) // Requires Spawn count and Min Delay to be set
				{
					tagsToSend.Add(new NbtShort(MaxSpawnName, MaxSpawnDelay));
				}

				tagsToSend.Add(new NbtShort(MaxNearbyEntitiesName, MaxNearbyEntities));

				if (MaxNearbyEntities > 0) // Requires MaxNearbyEntities to be set
					tagsToSend.Add(new NbtShort(RequiredPlayerName, RequiredPlayerRange));

			}
			else // Instead, we're going to send spawn potentials
			{
				NbtList sPotents = new NbtList(SpawnPotentialsName);
				NbtCompound cmp = new NbtCompound();
			}
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

		public SpawnerEntityData(Block parent) : base(parent)
		{
		}

		#region Constants

		public const string SpawnPotentialsName = "SpawnPotentials";
		public const string EntityName = "Entity";
		public const string WeightName = "Weight";
		public const string SpawnDataName = "SpawnData";
		public const string SpawnCountName = "SpawnCount";
		public const string SpawnRangeName = "SpawnRange";
		public const string DelayName = "Delay";
		public const string MinSpawnName = "MinSpawnDelay";
		public const string MaxSpawnName = "MaxSpawnDelay";
		public const string MaxNearbyEntitiesName = "MaxNearbyEntities";
		public const string RequiredPlayerName = "RequiredPlayerRange";

		#endregion
	}
}
