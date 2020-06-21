using System;
using System.Collections.Generic;
using System.Text;
using Redstone.AppSystem;
using Redstone.Players;
using Redstone.Worlds;

namespace Redstone.Recipes
{
	public class ShapelessRecipe : IRecipe
	{
		public Identifier ID { get; set; }

		public RecipeType Type => RecipeType.CraftingShapeless;

		public object[] Data
		{
			get
			{
				return new[]
				{
					Group,
					Ingredients.Length,
					Ingredients,
					(object) Result
				};
			}
		}

		public string Group { get; set; }

		public Material[] Ingredients { get; set; }

		public Slot Result { get; set; }
	}
}
