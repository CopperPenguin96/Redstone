using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Configuration.Sections
{
	public class Security : ConfigSection
	{
		public override string Name => "Security";

		public ConfigBool RequireAuth =
			new ConfigBool("require-auth",
				"Requires usernames be verified. Recommended to leave on otherwise usernames can be hacked.", true);

		public override void LoadDefaults()
		{
			RequireAuth.SetDefault();
		}
	}
}