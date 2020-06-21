using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Configuration.Sections
{
	public class Advanced : ConfigSection
	{
		public override string Name => "Advanced";

		public ConfigInt RenderDistance =
			new ConfigInt("render-distance", "How far players appear",
				32, 2, 32);

		public ConfigBool ReducedDebugInfo =
			new ConfigBool("reduced-debug-info", "If true, the client shows reduced info when F3 pressed.",
				false);

		public ConfigString IPAddress =
			new ConfigString("ip", "The IP of the server",
				"0.0.0.0");

		public override void LoadDefaults()
		{
			RenderDistance.SetDefault();
			ReducedDebugInfo.SetDefault();
			IPAddress.SetDefault();
		}
	}
}