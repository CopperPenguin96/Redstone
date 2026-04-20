using Redstone.Core.Chatting;
using Redstone.Core.Entities;
using Redstone.Core.Logging;
using Redstone.Core.Types;
using Redstone.Core.World;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Redstone.Core.Registries
{
    public sealed class RegistryManager
    {
        public const string DIR = "Registries/";
        public static Dictionary<Identifier, Registry> Registries { get; private set; } = new Dictionary<Identifier, Registry>();

        public static bool Initialized { get; private set; } = false;

        public static Dictionary<Identifier, string> RegistryLocations => new()
        {
            {  new Identifier("banner_pattern"), $"{DIR}BannerPatterns.json"  },
            { new Identifier("chat_type"), $"{DIR}ChatType.json" },
            { new Identifier("damage_type"), $"{DIR}DamageType.json" },
            { new Identifier("dimension_type"), $"{DIR}DimensionType.json" },
            { new Identifier("painting_variant"), $"{DIR}PaintingVariant.json" },
            { new Identifier("trim_material"), $"{DIR}TrimMaterial.json" },
            { new Identifier("trim_pattern"), $"{DIR}TrimPattern.json" },
            { new Identifier("wolf_variant"), $"{DIR}WolfVariant.json" },
            { new Identifier("worldgen/biome"), $"{DIR}Biome.json" }
        };

        internal static void Init()
        {
            Logger.LogSystem("Initializing Registry Manager...");

            if (Initialized)
            {
                Logger.LogWarning("Registry Manager is already initialized. Skipping initialization.");
                return;
            }
            
            LoadRegistry("banner_pattern", BannerPattern.Keys);
            LoadRegistry("chat_type", ChatType.Keys);
            LoadRegistry("damage_type", DamageType.Keys);
            LoadRegistry("Registries/DimensionType.json", Dimension.Keys);
            LoadRegistry("Registries/PaintingVariant.json", PaintingVariant.Keys);
            /*LoadRegistry("Registries/TrimMaterial.json", "trim_material");
            LoadRegistry("Registries/TrimPattern.json", "trim_pattern");
            LoadRegistry("Registries/WolfVariant.json", "wolf_variant");
            LoadRegistry("Registries/Biome.json", "worldgen/biome");*/

            Initialized = true;
        }

        private static void LoadRegistry(Identifier ident, Dictionary<Identifier, object> entries)
        {
            if (ident == null || entries == null)
            {
                RedstoneException.Throw(new ArgumentNullException("File, Identifier, and Entries cannot be null when loading a registry."));
            }

            Registries.Add(ident!, new Registry(ident!, entries!));
            Logger.LogSystem($"Loaded registry '{ident}' from file '{RegistryLocations[ident!]}'.");
        }


        private static string ReadJson(string location)
        {
            if (!File.Exists(location))
            {
                throw new RedstoneException(new FileNotFoundException($"The file for registry at location '{location}' was not found."), Severity.Fatal);
            }

            return File.ReadAllText(location);
        }
    }
}
