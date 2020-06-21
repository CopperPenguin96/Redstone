using System;
using System.Collections.Generic;
using System.Text;
using Redstone.AppSystem;

namespace Redstone.Recipes
{
	public class SpecialRepairItem : IRecipe
	{
		public Identifier ID { get; set; }
		public RecipeType Type => RecipeType.CraftingSpecialRepairItem;

		public object[] Data => new object[] { };
	}
}
