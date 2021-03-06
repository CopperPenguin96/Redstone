﻿using System;
using System.Collections.Generic;
using System.Text;
using fNbt;

namespace ProtocolSharp.Types
{
	/// <summary>
	/// From wiki.vg: The Slot data structure is how Minecraft represents an item and its
	/// associated data in the Minecraft Protocol
	/// </summary>
	public class Slot
	{
		/// <summary>
		/// True if there is an item in this position; false if empty
		/// </summary>
		public bool Present = false;

		/// <summary>
		/// The Item ID. Omitted if present is false. Item IDs are distinct from block IDs;
		/// </summary>
		public VarInt ItemID;

		/// <summary>
		/// Omitted if false
		/// </summary>
		public byte ItemCount;

		/// <summary>
		/// Omitted if present if false. If 0 (TAG_End), there is no NBT data, and no further
		/// data follows. Otherwise the byte is the start of an NBT blob.
		/// </summary>
		public NbtCompound NBT;


	}
}
