namespace Redstone.AppSystem.Exceptions
{
	public class ConfigLoadException : System.Exception
	{
		public ConfigLoadException()
		{

		}

		public ConfigLoadException(string message) : base(message)
		{

		}

		public ConfigLoadException(string message, System.Exception inner) : base(message, inner)
		{

		}

		public ConfigLoadException(System.Exception inner) : base("", inner)
		{

		}
	}
}
