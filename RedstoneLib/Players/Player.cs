using Redstone.AppSystem;

namespace Redstone.Players
{
	/// <summary>
	/// Represents a player and the client.
	/// </summary>
	public sealed class Player
	{
		public void SendMessage(Log log)
		{

		}

		public bool IsConsole { get; set; }

		public bool IsSuper { get; set; }

		public bool IsPlayer { get; set; }

		public bool CanReadDebug { get; set; }

		public string Username { get; set; }


		private string _displayName = string.Empty;

		public string? DisplayName
		{
			get => _displayName == string.Empty ? Username : _displayName;
			set => _displayName = value!;
		}

	}
}
