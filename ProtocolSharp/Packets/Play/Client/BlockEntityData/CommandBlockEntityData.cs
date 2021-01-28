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
		public bool HasCustomName => (string) ParentBlock[CustomNameName] != "";

		public string CustomName => (string) ParentBlock[CustomNameName];

		public string Command => (string) ParentBlock[CommandName];

		public int SuccessCount => (int) ParentBlock[SuccessCountName];

		public string LastOutput => (string) ParentBlock[LastOutputName];

		public bool TrackOutput => (bool) ParentBlock[TrackOutputName];

		public bool Powered => (bool) ParentBlock[PoweredName];

		public bool Auto => (bool) ParentBlock[AutoName];

		public bool ConditionMet => (bool) ParentBlock[ConditionMetName];

		public bool UpdateLastExecution => (bool) ParentBlock[UpdateLastName];

		public long LastExecution => (long) ParentBlock[LastName];

		public new void Send(ref MinecraftClient client, GameStream stream)
		{
			NbtCompound nbt = new NbtCompound(
				new NbtTag[]
				{
					new NbtString(CommandName, Command), 
					new NbtInt(SuccessCountName, SuccessCount),
					new NbtString(LastOutputName, LastOutput),
					new NbtByte(TrackOutputName, TrackOutput.ToByte()),
					new NbtByte(PoweredName, Powered.ToByte()), 
					new NbtByte(AutoName, Auto.ToByte()), 
					new NbtByte(ConditionMetName, ConditionMet.ToByte()), 
					new NbtByte(UpdateLastName, UpdateLastExecution.ToByte()), 
					new NbtLong(LastName, LastExecution)
				});

			if (HasCustomName) nbt.Add(new NbtString("CustomName", CustomName));

			base.Send(ref client, stream, 
				(int) BlockEntityDataAction.SetCommandBlockText,
				nbt);
		}

		public CommandBlockEntityData(Block parent) : base(parent)
		{
		}

		#region Constants

		public const string CustomNameName = "CustomName";
		public const string CommandName = "Command";
		public const string SuccessCountName = "SuccessCount";
		public const string LastOutputName = "LastOutput";
		public const string TrackOutputName = "TrackOutput";
		public const string PoweredName = "powered";
		public const string AutoName = "auto";
		public const string ConditionMetName = "conditionMet";
		public const string UpdateLastName = "UpdateLastExecution";
		public const string LastName = "LastExecution";

		#endregion
	}
}