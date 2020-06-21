using Redstone.AppSystem;
using Redstone.Players;
using Redstone.Worlds;

namespace Redstone.Recipes
{
	public class ShapedRecipe : IRecipe
	{
		public Identifier ID { get; set; }
		public RecipeType Type => RecipeType.CraftingShaped;
		 
		public object[] Data
		{
			get
			{
				return new[]
				{
					Width, 
					Height, 
					Group, 
					Ingredients, 
					(object) Result
				};
			}
		}

		public VarInt Width { get; set; }
		public VarInt Height { get; set; }

		public string Group { get; set; }

		public Material[] Ingredients { get; set; }

		public Slot Result { get; set; }
	}
}
