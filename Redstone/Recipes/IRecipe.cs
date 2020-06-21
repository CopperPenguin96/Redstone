using Redstone.AppSystem;
using Redstone.Players;

namespace Redstone.Recipes
{
	public interface IRecipe
	{
		Identifier ID { get; set; }

		RecipeType Type { get; }

		object[] Data { get; }
	}
}
