using System;
using System.Collections.Generic;
using System.Text;
using fNbt;
using ProtocolSharp.Network;
using ProtocolSharp.Utils;
using ProtocolSharp.Worlds.Blocks;

namespace ProtocolSharp.Packets.Play.Client.BlockEntityData
{
	public class CommandBlockEntityData : BlockEntityData
	{
		public bool HasCustomName => (string) ParentBlock.Data[0].Value != "";

		public string CustomName => (string) ParentBlock.Data[0].Value;

		public string Command => (string) ParentBlock.Data[1].Value;

		public int SuccessCount => (int) ParentBlock.Data[2].Value;

		public string LastOutput => (string) ParentBlock.Data[3].Value;

		public bool TrackOutput => (bool) ParentBlock.Data[4].Value;

		public bool Powered => (bool) ParentBlock.Data[5].Value;

		public bool Auto => (bool) ParentBlock.Data[6].Value;

		public bool ConditionMet => (bool) ParentBlock.Data[7].Value;

		public bool UpdateLastExecution => (bool) ParentBlock.Data[8].Value;

		public long LastExecution => (long) ParentBlock.Data[9].Value;

		public new void Send(ref MinecraftClient client, GameStream stream)
		{
			NbtCompound nbt = new NbtCompound(
				new NbtTag[]
				{
					new NbtString("Command", Command), 
					new NbtInt("SuccessCount", SuccessCount),
					new NbtString("LastOutput", LastOutput),
					new NbtByte("TrackOutput", TrackOutput.ToByte()),
					new NbtByte("powered", Powered.ToByte()), 
					new NbtByte("auto", Auto.ToByte()), 
					new NbtByte("conditionMet", ConditionMet.ToByte()), 
					new NbtByte("UpdateLastExecution", UpdateLastExecution.ToByte()), 
					new NbtLong("LastExecution", LastExecution)
				});

			if (HasCustomName) nbt.Add(new NbtString("CustomName", CustomName));

			base.Send(ref client, stream, 
				(int) BlockEntityDataAction.SetCommandBlockText,
				nbt);
		}

		public CommandBlockEntityData(Block parent) : base(parent)
		{
		}
	}
}