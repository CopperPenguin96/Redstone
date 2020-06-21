using System;
using System.Collections.Generic;
using System.Text;
using Redstone.AppSystem;

namespace Redstone.Recipes
{
	public class SpecialBannerAddPattern : IRecipe

	{
		public Identifier ID { get; set; }
		public RecipeType Type => RecipeType.CraftingSpecialBannerAddPattern;

		public object[] Data => new object[] { };
	}
}
