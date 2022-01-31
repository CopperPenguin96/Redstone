using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Redstone.Utils;

namespace Redstone.Worlds
{
    public sealed class WorldManager
    {
        public const string Dir = "Redstone/Worlds/";

        public static List<World> Worlds = new();

        public static void Load()
        {
            bool noWorlds = false;

            if (!Directory.Exists(Dir))
            {
                noWorlds = true;
                Directory.CreateDirectory(Dir);
            }

            string worldMaps = Dir + "worldMap.json";
            if (!File.Exists(worldMaps))
            {
                noWorlds = true;
            }
            else
            {
                string json = File.ReadAllText(worldMaps);
                WorldMap worldMap = JsonConvert.DeserializeObject<WorldMap>(json);
                if (worldMap.Names.Length < 1) noWorlds = true;
                else
                {
                    int loaded = 0;
                    foreach (string w in worldMap.Names)
                    {
                        bool worldLoaded = World.TryLoad(w, out World world, out Exception ex);
                        if (worldLoaded)
                        {
                            loaded++;
                            Worlds.Add(world);
                        }
                        else
                        {
                            Logger.LogError(
                                $"There was a problem loading world {w}: {ex}");
                        }
                    }

                    if (loaded == 0)
                    {
                        noWorlds = true;
                    }
                }
            }

            if (!noWorlds)
            {
                Logger.LogWarning("World Manager: No worlds were found. Creating default world");
                World world = new World();
            }
        }
    }
}
