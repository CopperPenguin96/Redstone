using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Configuration.Sections
{
	public class Misc : ConfigSection
	{
		public override string Name => "Misc";

		public ConfigBool LockDifficulty =
			new ConfigBool("lock-difficulty",
				"Whether or not to force difficulty",
				false);

		public override void LoadDefaults()
		{
			LockDifficulty.SetDefault();
		}
	}
}