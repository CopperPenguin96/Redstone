using System;
using System.Collections.Generic;
using System.Text;
using Redstone.AppSystem;
using Redstone.Players;
using Redstone.Worlds;

namespace Redstone.Recipes
{
	public class Smelting : IRecipe
	{
		public Identifier ID { get; set; }
		public RecipeType Type => RecipeType.Smelting;

		public object[] Data
		{
			get
			{
				return new[]
				{
					Group,
					Ingredient,
					(object) Result,
					Experience,
					CookingTime
				};
			}
		}

		public string Group { get; set; }

		public Material Ingredient { get; set; }

		public Slot Result { get; set; }

		public float Experience { get; set; }

		public VarInt CookingTime { get; set; }
	}
}
