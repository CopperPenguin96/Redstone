using System;

namespace ProtocolSharp.Types
{
	public class Identifier
	{
		public string Namespace { get; set; } = "minecraft";

		public string Name { get; set; }

		public override string ToString()
		{
			return $"{Namespace}:{Name}";
		}

		public Identifier(string ns, string nm)
		{
			Namespace = ns ?? "minecraft";
			Name = nm ?? throw new ArgumentNullException(nameof(nm));
		}

		public Identifier(string name)
		{
			Name = name ?? throw new ArgumentNullException(nameof(name));
		}
	}
}
