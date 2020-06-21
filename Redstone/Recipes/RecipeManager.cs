using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Redstone.Recipes
{
	public class RecipeManager
	{
		public const string Dir = "Redstone/Recipes/";
		public static List<IRecipe> Recipes = new List<IRecipe>();

		public static void Load()
		{
			string[] recipeFiles = Directory.GetFiles(Dir);
			foreach (string file in recipeFiles)
			{
				string conts = File.ReadAllText(file);
				IRecipe recipe = JsonConvert.DeserializeObject<IRecipe>(conts);
				Recipes.Add(recipe);
			}
		}
	}
}
