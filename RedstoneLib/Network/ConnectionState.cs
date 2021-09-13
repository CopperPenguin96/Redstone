namespace Redstone.Network
{
	/// <summary>
	/// Current state of the connection.
	/// </summary>
	public enum ConnectionState
	{
		Handshake,
		Status,
		Login,
		Play
	}
}
