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
		public bool IsLocked => (string) ParentBlock.Data[0].Value != "";

		public string UserLock => (string) ParentBlock.Data[0].Value;

		public int Levels => (int) ParentBlock.Data[1].Value;

		public int PrimaryPower => (int) ParentBlock.Data[2].Value;

		public int SecondaryPower => (int) ParentBlock.Data[3].Value;

		public new void Send(ref MinecraftClient client, GameStream stream)
		{
			NbtCompound nbt = new NbtCompound(
				new[]
				{
					new NbtInt("Levels", Levels),
					new NbtInt("Primary", PrimaryPower),
					new NbtInt("Secondary", SecondaryPower) 
				});

			if (IsLocked)
			{
				nbt.Add(new NbtString("Lock", UserLock));
			}

			base.Send(ref client, stream, 
				(int) BlockEntityDataAction.SetBeaconPowers,
				nbt);
		}

		public BeaconEntityData(Block parent) : base(parent)
		{
		}
	}
}