using System;
using System.Collections.Generic;
using System.Text;
using Redstone.AppSystem;

namespace Redstone.Recipes
{
	public class SpecialMapCloning : IRecipe
	{
		public Identifier ID { get; set; }
		public RecipeType Type => RecipeType.CraftingSpecialMapCloning;

		public object[] Data => new object[] { };
	}
}
