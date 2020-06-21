using System;
using System.Collections.Generic;
using System.Text;
using Redstone.AppSystem;

namespace Redstone.Recipes
{
	public class SpecialBookCloning : IRecipe
	{
		public Identifier ID { get; set; }
		public RecipeType Type => RecipeType.CraftingSpecialBookCloning;

		public object[] Data => new object[] { };
	}
}
