using System;
using System.Collections.Generic;
using System.Text;
using fNbt;
using ProtocolSharp.Network;
using ProtocolSharp.Packets.Exceptions;
using ProtocolSharp.Types;
using ProtocolSharp.Worlds.Blocks;

namespace ProtocolSharp.Packets.Play.Client.BlockEntityData
{
	public class BlockEntityData : ISendingPacket
	{
		public Packet Packet => Packet.BlockEntityData;

		public Position Position { get; set; }

		public Block ParentBlock { get; set; }

		public string Name => "Block Entity Data";

		public void Send(ref MinecraftClient client, GameStream stream)
		{
			throw new InvalidPacketUseException();
		}

		public BlockEntityData(Block parent)
		{
			ParentBlock = parent ?? throw new ArgumentNullException(nameof(parent));
		}

		public void Send(ref MinecraftClient client, GameStream stream,
			VarInt da, NbtCompound nbt)
		{
			Protocol.Send(ref client, stream, Packet, Position, da, nbt);
		}
	}
}
