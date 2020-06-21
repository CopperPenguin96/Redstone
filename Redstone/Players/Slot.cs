using System;
using System.Collections.Generic;
using System.Text;
using Redstone.AppSystem;
using fNbt;
namespace Redstone.Players
{
	public class Slot
	{
		public bool Present { get; set; }

		public VarInt ItemID { get; set; }

		private byte _count;

		public byte Count
		{
			get => _count;
			set => _count = value > 64 ? (byte) 64 : value;
		}

		public NbtTag Nbt { get; set; }
	}
}
