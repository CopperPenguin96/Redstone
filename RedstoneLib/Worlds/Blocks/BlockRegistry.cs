using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Redstone.Worlds.Blocks
{
	public class BlockRegistry
	{
		public static List<Block> Blocks = new List<Block>();

		private static string _json;
		public static JsonDocument Doc;
		public static void Init()
		{
			// Load the blocks file from resources
			string file;
			var assembly = typeof(BlockRegistry).GetTypeInfo().Assembly;
			using (var stream = assembly.GetManifestResourceStream("Redstone.blocks.json"))
			{
				using (var reader = new StreamReader(stream))
				{
					file = reader.ReadToEnd();
				}
			}

			_json = file;
			Doc = JsonDocument.Parse(_json);

		}

		#region Blocks

		public static Block NoteBlock = new Block("note_block");
		public static Block Piston = new Block("piston");
		public static Block StickyPiston = new Block("sticky_piston");
		public static Block Chest = new Chest();
		public static Block EnderChest = new EnderChest();
		public static Block Beacon = new Block("beacon");
		public static Block Spawner = new Block("spawner");
		public static Block EndGateway = new Block("end_gateway");
		public static Block ShulkerBox = new ShulkerBox();
		public static Block Bell = new Block("bell");

		#endregion
	}
}
