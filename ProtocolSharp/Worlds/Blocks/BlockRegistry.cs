using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace ProtocolSharp.Worlds.Blocks
{
	public class BlockRegistry
	{
		public static List<Block> Blocks = new List<Block>();

		internal static bool IsInit = false;

		public static void Init()
		{
			Blocks = LoadFromJson(GetEmbeddedResource("ProtocolSharp", "blocks.json"));
			IsInit = true;
		}

		public static List<Block> LoadFromJson(string json)
		{
			JArray obj = JArray.Parse(json);

			return obj.Select(token => token.ToObject<Block>()).ToList();
		}

		private static string GetEmbeddedResource(string namespacename, string filename)
		{
			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = namespacename + "." + filename;

			using (Stream stream = assembly.GetManifestResourceStream(resourceName))
			using (StreamReader reader = new StreamReader(stream))
			{
				string result = reader.ReadToEnd();
				return result;
			}
		}
	}
}
