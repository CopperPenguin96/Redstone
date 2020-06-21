using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.AppSystem
{
	public sealed class Identifier
	{
		public string Namespace { get; set; }
		public string Name { get; set; }

		public Identifier()
		{

		}

		public Identifier(string namesp, string name)
		{
			Namespace = namesp ?? "minecraft";
			Name = name ?? throw new ArgumentNullException(nameof(name));
		}

		public Identifier(string name) : this(null, name)
		{

		}

		public override string ToString()
		{
			return $"{Namespace}:{Name}";
		}
	}
}
