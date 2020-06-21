using System;
using System.Collections.Generic;
using System.Text;
using Redstone.AppSystem;
using Redstone.Commands;
using Redstone.Configuration;
using Redstone.Players;

namespace Redstone.Network.Packets.Play
{
	public class DeclareCommands : IPacket
	{
		public Packet ID => Packet.DeclareRecipes;
		public string Name => "Declare Commands";

		public void Send(ref Player player, GameStream stream)
		{
			List<CommandNode> nodes = new List<CommandNode>();
			foreach (Command command in CommandManager.AllCommands)
			{
				CommandNode node = new CommandNode
				{
					Name = command.Name, Parser = new Identifier("redstone", command.Name)
				};

				nodes.Add(node);
			}

			
		}

		public void Receive(ref Player player, GameStream stream)
		{
			throw new NotImplementedException();
		}
	}
}
