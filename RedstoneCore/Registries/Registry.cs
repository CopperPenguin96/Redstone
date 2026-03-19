using Redstone.Core.Types;
using System.Text.Json;
using System.Text.Json.Nodes;
using Attribute = Redstone.Core.Types.Attribute;

namespace Redstone.Core.Registries
{
    public sealed class Registry
    {
        public const string DIR = "Registries/";

        public static bool Initialized { get; private set; } = false;
        public static Dictionary<VarInt, Attribute> Attributes { get; private set; }

        public static Dictionary<VarInt, Identifier> Particles { get; private set; }

        internal static void Init()
        {
            if (Initialized) return;
            ParseAttributes();
            ParseParticles();

            Initialized = true;
        }

        public static void ParseAttributes()
        {
            Attributes = new();

            JsonArray attriJson = JsonNode.Parse(ReadJson(DIR + "Attributes.json"))!.AsArray();

            VarInt index = 0;
            foreach (JsonNode? node in attriJson)
            {
                if (node is not JsonObject obj)
                {
                    throw new RedstoneException("Expected a JSON object in the attributes registry, but found a different type.");
                }

                Attributes.Add(index, new Attribute(ReadJson(DIR + "attributes.json")));
                index++;
            }
        }

        public static void ParseParticles()
        {
            Particles = new();
            JsonArray particleJson = JsonNode.Parse(ReadJson(DIR + "Particles.json"))!.AsArray();

            foreach (JsonNode? node in particleJson)
            {
                if (node is not JsonObject obj)
                {
                    throw new RedstoneException("Expected a JSON object in the particles registry, but found a different type.");
                }

                VarInt id = node.AsObject()["id"]!.GetValue<int>();
                Identifier name = node.AsObject()["name"]!.GetValue<string>();

                Particles.Add(id, name);
            }
        }

        private static string ReadJson(string location)
        {
            if (!File.Exists(location))
            {
                throw new RedstoneException(new FileNotFoundException($"The file at location '{location}' was not found."));
            }

            return File.ReadAllText(location);
        }
    }
}
