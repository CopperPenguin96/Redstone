using Redstone.Players;

namespace Redstone.Network.Packets
{
	internal interface IPacket
	{
		Packet ID { get; }

		string Name { get; }

		void Send(ref Player player, GameStream stream);

		void Receive(ref Player player, GameStream stream);
	}
}
