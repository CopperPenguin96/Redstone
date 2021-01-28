using System;
using System.Collections.Generic;
using System.Text;
using fNbt;
using ProtocolSharp.Network;
using ProtocolSharp.Worlds.Blocks;

namespace ProtocolSharp.Packets.Play.Client.BlockEntityData
{
	public class BeaconEntityData : BlockEntityData
	{
		public bool IsLocked => (string) ParentBlock[LockName] != "";

		public string UserLock => (string) ParentBlock[LockName];

		public int Levels => (int) ParentBlock[LevelsName];

		public int PrimaryPower => (int) ParentBlock[PrimaryName];

		public int SecondaryPower => (int) ParentBlock[SecondaryName];

		public new void Send(ref MinecraftClient client, GameStream stream)
		{
			NbtCompound nbt = new NbtCompound(
				new[]
				{
					new NbtInt(LevelsName, Levels),
					new NbtInt(PrimaryName, PrimaryPower),
					new NbtInt(SecondaryName, SecondaryPower) 
				});

			if (IsLocked)
			{
				nbt.Add(new NbtString(LockName, UserLock));
			}

			base.Send(ref client, stream, 
				(int) BlockEntityDataAction.SetBeaconPowers,
				nbt);
		}

		public BeaconEntityData(Block parent) : base(parent)
		{
		}

		#region Constants

		public const string LockName = "Lock";
		public const string LevelsName = "Levels";
		public const string PrimaryName = "Primary";
		public const string SecondaryName = "Secondary";

		#endregion
	}
}