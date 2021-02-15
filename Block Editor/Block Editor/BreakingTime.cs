using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block_Editor
{
	public class BreakingTime
	{
		public ToolType ToolType { get; set; }

		public decimal Value { get; set; }

		public BreakingTime(ToolType type, decimal value)
		{
			ToolType = type;
			Value = value;
		}
	}
}
