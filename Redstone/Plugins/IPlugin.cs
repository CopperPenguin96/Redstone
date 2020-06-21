using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Plugins
{
	public interface IPlugin
	{
		/// <summary>
		/// The name of the plugin. Should be short and sweet.
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Unique identifier for the plugin. How the server will call upon it.
		/// </summary>
		string UUID { get; set; }

		/// <summary>
		/// Who created this?
		/// </summary>
		string Author { get; set; }

		/// <summary>
		/// Versions of Redstone this plugin works with.
		/// </summary>
		Version[] WorksWith { get; set; }

		/// <summary>
		/// Array of plugins this plugin requires to work.
		/// If said plugins don't exist, plugin won't load.
		/// </summary>
		string[] RequiredPlugins { get; set; }

		/// <summary>
		/// Called when the plugin is loaded by the server.
		/// Most likely happens at start/restart. May be changed
		/// by player with correct permissions.
		/// </summary>
		void Enable();

		/// <summary>
		/// Called when the plugin is being disabled by the server.
		/// Most likely happens at close/restart. May be changed
		/// by player with correct permissions.
		/// </summary>
		void Disable();
	}
}
