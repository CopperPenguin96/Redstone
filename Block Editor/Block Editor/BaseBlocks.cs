using System.Collections.Generic;

namespace Block_Editor
{
	public abstract class BaseBlocks
	{
		private static List<BreakingTime> SameForAll(double time)
		{
			return Bt(time, time, time, time, time, time, time);
		}

		private static List<BreakingTime> Bt(double def, double wood, double stone, double iron,
			double diamond, double nether, double gold, double shears = -1, double sword = -1)
		{
			List<BreakingTime> bt = new List<BreakingTime>
			{
				new BreakingTime(ToolType.Default, (decimal) def),
				new BreakingTime(ToolType.Wooden, (decimal) wood),
				new BreakingTime(ToolType.Stone, (decimal) stone),
				new BreakingTime(ToolType.Iron, (decimal) iron),
				new BreakingTime(ToolType.Diamond, (decimal) diamond),
				new BreakingTime(ToolType.Netherite, (decimal) nether),
				new BreakingTime(ToolType.Golden, (decimal) gold),
				new BreakingTime(ToolType.Shears, (decimal) shears),
				new BreakingTime(ToolType.Sword, (decimal) sword)
			};

			return bt;
		}

		public static readonly Block Log = new Block(true)
		{
			Renewable = true,
			IsStackable = new Stackable(true, Stackable.Max),
			ToolRequired = ToolForm.Axe,
			BreakingTimes = Bt(3, 1.5, 0.75, 0.5, 0.4, 0.35, 0.25),
			BlastResistance = 2,
			Hardness = 2,
			Luminant = false,
			Transparent = false,
			Flammable = true,
			LavaFlammable = true,
			NetherFlammable = true,
			NetherLavaFlammable = true,
			ID = "base_log"
		};

		public static readonly Block Leaves = new Block(true)
		{
			Renewable = true,
			IsStackable = new Stackable(true, Stackable.Max),
			ToolRequired = ToolForm.Hoe,
			BreakingTimes = Bt(0.3, 0.15, 0.1, 0.05, 0.05, 0.05, 0.05, 0.05, 0.2),
			BlastResistance = 0.2,
			Hardness = 0.2,
			Luminant = false,
			Transparent = Transparency.Partial,
			Flammable = true,
			LavaFlammable = true,
			ID = "base_leaves"
		};

		public static readonly Block Gate = new Block(true)
		{
			Renewable = true,
			IsStackable = new Stackable(true, Stackable.Max),
			ToolRequired = ToolForm.Hand,
			BreakingTimes = Bt(3, 1.5, 0.75, 0.5, 0.4, 0.35, 0.25),
			BlastResistance = 3,
			Hardness = 2,
			Luminant = false,
			Transparent = true,
			Flammable = true,
			NetherFlammable = false,
			LavaFlammable = true,
			NetherLavaFlammable = false,
			ID = "base_fence_gate",
			CraftRecipe = new List<string[,]>
			{
				new string[,]
				{
					{
						"air", "air", "air"
					},
					{
						"stick", "base_plank", "stick"
					},
					{
						"stick", "base_plank", "stick"
					}
				},
			}
		};

		public static readonly Block Fence = new Block(true)
		{
			Renewable = true,
			IsStackable = new Stackable(true, Stackable.Max),
			ToolRequired = ToolForm.Hand,
			BreakingTimes = Bt(3, 1.5, 0.75, 0.5, 0.4, 0.35, 0.25),
			BlastResistance = 3,
			Hardness = 2,
			Luminant = false,
			Transparent = true,
			Flammable = true,
			LavaFlammable = true,
			ID = "base_fence",
			CraftRecipe = new List<string[,]>
			{
				new string[,]
				{
					{
						"air", "air", "air"
					},
					{
						"base_plank", "stick", "base_plank"
					},
					{
						"base_plank", "base_stick", "base_plank"
					}
				},
			}
		};

		public static readonly Block Door = new Block(true)
		{
			Renewable = true,
			IsStackable = new Stackable(true, Stackable.Max),
			ToolRequired = ToolForm.Hand,
			BreakingTimes = Bt(4.5, 2.25, 1.15, 0.75, 0.6, 0.5, 0.4),
			BlastResistance = 3,
			Hardness = 3,
			Luminant = false, 
			Transparent = Transparency.Partial,
			Flammable = false,
			LavaFlammable = true,
			ID = "base_door",
			CraftRecipe = new List<string[,]>
			{
				new string[,]
				{
					{
						"base_log", "base_log", "air"
					},
					{
						"base_log", "base_log", "air"
					},
					{
						"base_log", "base_log", "air"
					}
				}
			}
		};

		public static readonly Block Button = new Block(true)
		{
			Renewable = true,
			IsStackable = new Stackable(true, Stackable.Max),
			ToolRequired = ToolForm.Hand,
			BreakingTimes = Bt(0.75, 0.4, 0.2, 0.15, 0.1, 0.1, 0.1),
			BlastResistance = 0.5,
			Hardness = 0.5,
			Luminant = false,
			Transparent = true,
			Flammable = false,
			LavaFlammable = false,
			ID = "base_button",
			BlockTagsJE = new List<string> {"buttons"}
		};

		public static readonly Block Bed = new Block(true)
		{
			IsStackable = false,
			ToolRequired = ToolForm.Hand,
			BreakingTimes = SameForAll(0.2),
			BlastResistance = 0.2,
			Hardness = 0.2,
			Luminant = false,
			Transparent = true,
			Flammable = true,
			LavaFlammable = true,
			ID = "base_bed",
			BlockTagsJE = new List<string> {"beds"},
			TranslationKey = "bed",
			CraftRecipe = new List<string[,]>
			{
				new string[,]
				{
					{
						"air", "air", "air"
					},
					{
						"base_wool", "base_wool", "base_wool"
					},
					{
						"base_plank", "base_plank", "base_plank"
					}
				},
				new string[,]
				{
					{
						"base_bed", "base_dye"
					},
					{
						"air", "air"
					}
				},
				new string[,]
				{
					{
						"base_bed", "bleach"
					},
					{
						"air", "air"
					}
				},
			}
		};
	}
}