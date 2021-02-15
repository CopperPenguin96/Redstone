using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block_Editor
{
	public class Block
	{
		public virtual string Name { get; set; }

		public virtual Stackable IsStackable { get; set; }

		public virtual bool IsBaseType { get; set; }

		public virtual Form1.ToolForm ToolRequired { get; set; }

		public virtual List<BreakingTime> BreakingTimes { get; set; }

		public virtual double BlastResistance { get; set; }

		public virtual double Hardness { get; set; }

		public virtual bool Luminant { get; set; }

		public virtual bool Transparent { get; set; }

		public virtual bool Flammable { get; set; }

		public virtual bool LavaFlammable { get; set; }

		public virtual List<string[,]> CraftRecipe { get; set; }

		public virtual string ID { get; set; }

		public virtual List<string> BlockTagsJE { get; set; }

		public virtual string TranslationKey { get; set; }

		public bool Renewable { get; set; }

		public string BaseTypeName { get; set; } // Maybe use?

		public Block()
		{
			IsBaseType = false;
		}

		public Block(bool isBase)
		{
			IsBaseType = isBase;
		}
	}
}
