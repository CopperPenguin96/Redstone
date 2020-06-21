using System;
using System.Collections.Generic;
using System.Text;
using Redstone.AppSystem;

namespace Redstone.Configuration
{
	public class CommandNode
	{
		public byte Flags { get; set; }

		public VarInt[] Children { get; set; }

		public VarInt RedirectNode { get; set; }

		public string Name { get; set; }

		public Identifier Parser { get; set; }

		public object[] Properties { get; set; }

		public Identifier SuggestionsType { get; set; }
	}

	[Flags]
	public enum NodeFlags : byte
	{
		NodeType = 0x03,
		IsExecutable = 0x04,
		HasRedirect = 0x08,
		HasSuggestionsType = 0x10
	}

	[Flags]
	public enum NodeTypeFlags : byte
	{
		Root = 0,
		Literal = 1,
		Argument = 2,
		Unused = 3
	}
}
