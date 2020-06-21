using System;
using System.Collections.Generic;
using System.Text;
using Redstone.AppSystem;

namespace Redstone.Recipes
{
	public class SpecialBannerDuplicate : IRecipe
	{
		public Identifier ID { get; set; }
		public RecipeType Type => RecipeType.CraftingSpecialBannerDuplicate;

		public object[] Data => new object[] { };
	}
}
