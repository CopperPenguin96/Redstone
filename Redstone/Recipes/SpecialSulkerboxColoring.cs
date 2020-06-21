using System;
using System.Collections.Generic;
using System.Text;
using Redstone.AppSystem;

namespace Redstone.Recipes
{
	public class SpecialShulkerboxColoring : IRecipe
	{
		public Identifier ID { get; set; }
		public RecipeType Type => RecipeType.CraftingSpecialShulkerBoxColoring;

		public object[] Data => new object[] { };
	}
}
