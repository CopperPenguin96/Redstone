using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.AppSystem.Logging
{
	public enum LogType
	{
		/// <summary>
		/// Normal, everyday logs
		/// </summary>
		Normal,

		/// <summary>
		/// Small errors and issues.
		/// </summary>
		Warning,

		/// <summary>
		/// More serious issues like missing files, etc.
		/// </summary>
		Error,

		/// <summary>
		/// Very serious issues that will force a shutdown.
		/// </summary>
		Crash,

		/// <summary>
		/// Internal server activity
		/// </summary>
		SystemActivity,

		/// <summary>
		/// Messages to console
		/// </summary>
		ConsoleOutput,

		/// <summary>
		/// Input from console
		/// </summary>
		ConsoleInput,

		/// <summary>
		/// From player actions
		/// </summary>
		PlayerActivity
	}
}
