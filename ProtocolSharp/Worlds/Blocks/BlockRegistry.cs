using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace ProtocolSharp.Worlds.Blocks
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
            using (var stream = assembly.GetManifestResourceStream("ProtocolSharp.blocks.json"))
            {
                using (var reader = new StreamReader(stream))
                {
                    file = reader.ReadToEnd();
                }
            }

            _json = file;
            Doc = JsonDocument.Parse(_json);
            
        }
    }
}
