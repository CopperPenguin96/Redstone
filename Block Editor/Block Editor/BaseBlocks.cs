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
			double diamond, double nether, double gold)
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
			};

			return bt;
		}
		// Name, Stackable, ToolReq, BreakingTimes, Blast, Hardness
		// Lum, Trans, Flamm, LavaFlamm, Craft, ID, BlockTags?, TransKey
		public static readonly Block Bed = new Block(true)
		{
			Name = "Bed",
			IsStackable = false,
			ToolRequired = Form1.ToolForm.Hand,
			BreakingTimes = SameForAll(0.2),
			BlastResistance = 0.2,
			Hardness = 0.2,
			Luminant = false,
			Transparent = true,
			Flammable = true,
			LavaFlammable = true,
			ID = "bed",
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
						"wool", "wool", "wool"
					},
					{
						"plank", "plank", "plank"
					}
				},
				new string[,]
				{
					{
						"bed", "dye"
					},
					{
						"air", "air"
					}
				}
			}
		};
	}
}