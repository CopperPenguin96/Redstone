namespace ProtocolSharp.Types
{
	public class Identifier
	{
		public string Namespace { get; set; }

		public string Name { get; set; }

		public override string ToString()
		{
			return $"{Namespace}:{Name}";
		}
	}
}
