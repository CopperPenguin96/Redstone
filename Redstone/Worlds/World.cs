using System;
using System.Collections.Generic;
using System.Text;
using Redstone.Utils;

namespace Redstone.Worlds
{
	public class World
	{
		public string Seed { get; private set; }

		public string Name { get; set; }

		private string _id;

		public string ID => _id ?? (_id = Randomness.RandomString(13));

		public string LevelType { get; private set; }

		public bool ImmediateRespawn { get; set; }

		public World(string name)
		{
			_id = Randomness.RandomString(13);
		}
	}
}
