using System;
using System.Collections.Generic;
using System.Text;
using Redstone.Worlds;

namespace Redstone.Configuration.Sections
{
	public class Worlds : ConfigSection
	{
		public override string Name => "Worlds";

		public ConfigProperty<Dimension> DefaultDimension =
			new ConfigProperty<Dimension>("default-dimension",
				"The default dimension for the server (nether, overworld, end).",
				Dimension.Overworld);

		public override void LoadDefaults()
		{
			DefaultDimension.SetDefault();
		}
	}
}