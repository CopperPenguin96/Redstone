namespace Redstone.Network.Packets
{
	/// <summary>
	/// Interface detailing packets received from the client.
	/// </summary>
	public interface IReceivingPacket
	{
		Packet Packet { get; }

		string Name { get; }

		void Receive(ref MinecraftClient client, GameStream stream);
	}
}
