using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlockUpdater
{
	class Program
	{
		public static List<Block> blks = new List<Block>();
		static void Main(string[] args)
		{
			var reader = File.ReadAllText("file.json");
			blks = JsonConvert.DeserializeObject<List<Block>>(reader);

			var updateText = File.ReadAllLines("updates.txt");

			List<UpdateInfo> updates = (from line in updateText let spot1 = line.IndexOf(",") let type = int.Parse(line.Substring(0, spot1)) let cut = line.Substring(spot1 + 1) let spot2 = cut.IndexOf(",") let meta = int.Parse(cut.Substring(0, spot2)) let cutFinal = cut.Substring(spot2 + 1) select new UpdateInfo {Type = type, Meta = meta, Text = cutFinal}).ToList();

			List<int> types = new List<int>();
			List<int> metas = new List<int>();
			List<string> duplicates = new List<string>();

			List<UpdateInfo> dontExist = new List<UpdateInfo>();
			List<int> remoteIndex = new List<int>();

			int loopCount = 0;
			foreach (var i in updates) // Checks for duplicates
			{
				foreach (int type in types)
				{
					types.Add(type);
					if (type != i.Type) continue;
					foreach (int meta in metas)
					{
						metas.Add(meta);
						if (meta == i.Meta)
						{
							duplicates.Add(type + ",");
						}
					}
				}

				bool found = false;
				// check for ones that don't exist
				foreach (var b in blks.Where(b => b.type == i.Type && b.meta == i.Meta))
				{
					found = true;
				}

				if (!found)
				{
					dontExist.Add(i);
					remoteIndex.Add(loopCount);
				}

				loopCount++;
			}

			Console.WriteLine("Found " + dontExist.Count + " record(s) that don't exist yet.");
			foreach (var b in dontExist)
			{
				Console.WriteLine("Adding " + b.Text);
				Block blk = new Block
				{
					type = b.Type,
					meta = b.Meta,
					name = b.Text
				};

				Add(blk);
			}

			if (duplicates.Count == 0) Console.WriteLine("No duplicates found.");
			else
			{
				Console.WriteLine(duplicates.Count +
				                  " duplicate(s) found. You will need to correct these before continuing.");
				foreach (string s in duplicates)
				{
					Console.WriteLine(s);
				}

				Console.ReadLine();
			}



			Console.WriteLine("Calculating " + updates.Count + " update(s)");
			foreach (UpdateInfo i in updates)
			{
				UpdateBlock(i.Type, i.Meta, i.Text, out var text);
				Console.WriteLine("Updated " + i.Type + "," + i.Meta + " to reflect " + i.Text + " instead of " + text);
			}

			Console.WriteLine("Saving the updated file...");
			int num = Directory.GetFiles(Directory.GetCurrentDirectory()).Length + 1;
			string file = "file" + num + ".json";
			File.WriteAllText(file, JsonConvert.SerializeObject(blks, Formatting.Indented));
			Console.WriteLine("Done!");
			Console.WriteLine("Generate block definitions...");
			string conts = blks.Select(b => "public static Block " + b.name.Replace(" ", "") + " = new Block(\"" + b.text_type + "\");").Aggregate("", (current, line) => current + (line + "\n"));
			if (File.Exists("defs.txt")) File.Delete("defs.txt");

			File.WriteAllText("defs.txt", conts);
			Console.WriteLine("Done!");
			Console.ReadLine();
		}

		private static void Add(Block blk)
		{
			blks.Add(blk);

		}
		private static void UpdateBlock(int type, int meta, string t, out string old)
		{
			for (int x = 0; x < blks.Count; x++)
			{
				Block b = blks[x];
				if (b.type != type || b.meta != meta) continue;
				b.legacy_type = b.text_type;
				b.text_type = t;
				blks[x] = b;
				old = b.legacy_type;
				return;
			}


			old = null;
		}
	}

	public class UpdateInfo
	{
		public int Type { get; set; }

		public int Meta { get; set; }

		public string Text { get; set; }
	}
	public class Block
	{
		public int type;
		public int meta;
		public string name;
		public string text_type;
		public string legacy_type;

	}
}
