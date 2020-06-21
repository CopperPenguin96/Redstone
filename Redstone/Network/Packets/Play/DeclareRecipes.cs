using System;
using System.Collections.Generic;
using System.Text;
using Redstone.AppSystem;
using Redstone.Players;
using Redstone.Recipes;

namespace Redstone.Network.Packets.Play
{
	public class DeclareRecipes : IPacket
	{
		public Packet ID => Packet.DeclareRecipes;
		public string Name => "Declare Recipes";

		public void Send(ref Player player, GameStream stream)
		{
			VarInt amountOfRecipes = RecipeManager.Recipes.Count;
			List<object> dataToWrite = new List<object>();

			foreach (IRecipe recipe in RecipeManager.Recipes)
			{
				dataToWrite.Add(recipe.ID);
				dataToWrite.Add(GetTypeName(recipe.Type));
				dataToWrite.AddRange(recipe.Data);
			}

			Protocol.Send(ref player, stream, ID,amountOfRecipes, dataToWrite);
		}

		private string GetTypeName(RecipeType type)
		{
			switch (type)
			{
				case RecipeType.CraftingShapeless: return "crafting_shapeless";
				case RecipeType.CraftingShaped: return "crafting_shaped";
				case RecipeType.CraftingSpecialArmorDye: return "crafting_special_armor_dye";
				case RecipeType.CraftingSpecialBookCloning: return "crafting_special_bookcloning";
				case RecipeType.CraftingSpecialMapCloning: return "crafting_special_mapcloning";
				case RecipeType.CraftingSpecialMapExtending: return "crafting_special_mapextending";
				case RecipeType.CraftingSpecialFireworkRocket: return "crafting_special_firework_rocket";
				case RecipeType.CraftingSpecialFireworkStar: return "crafting_special_firework_star";
				case RecipeType.CraftingSpecialFireworkStarFade: return "crafting_special_firework_star_fade";
				case RecipeType.CraftingSpecialRepairItem: return "crafting_special_repairitem";
				case RecipeType.CraftingSpecialTippedArrow: return "crafting_special_tippedarrow";
				case RecipeType.CraftingSpecialBannerDuplicate: return "crafting_special_bannerduplicate";
				case RecipeType.CraftingSpecialBannerAddPattern: return "crafting_special_banneraddpattern";
				case RecipeType.CraftingSpecialShieldDecoration: return "crafting_special_shielddecoration";
				case RecipeType.CraftingSpecialShulkerBoxColoring: return "crafting_special_shulkerboxcoloring";
				case RecipeType.Smelting: return "smelting";
				default: return null;
			}
		}

		public void Receive(ref Player player, GameStream stream)
		{
			throw new NotImplementedException();
		}
	}
}
