using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Configuration.Sections
{
	public class ConfigSection
	{
		public virtual string Name { get; }

		public virtual void LoadDefaults()
		{

		}
	}
}
