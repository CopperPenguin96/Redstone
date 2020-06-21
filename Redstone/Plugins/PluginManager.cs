using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Plugins
{
	public class PluginManager
	{
		public static List<IPlugin> Plugins = new List<IPlugin>();

		/// <summary>
		/// Gets plugin based on uuid.
		/// Returns null if plugin was not loaded or does not exist.
		/// </summary>
		public static IPlugin FromID(string uuid)
		{
			if (uuid == null) throw new ArgumentNullException(nameof(uuid));

			return Plugins.FirstOrDefault(pl => pl.UUID == uuid);
		}

		/// <summary>
		/// Determines if a plugin has been loaded (some errors or crashes might
		/// prevent a plugin from loading)
		/// or does not exist.
		/// </summary>
		public static bool PluginLoadedOrExists(string uuid)
		{
			return FromID(uuid) != null;
		}
	}
}
