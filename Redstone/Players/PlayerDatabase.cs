using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Redstone.Utils;

namespace Redstone.Players
{
    internal class PlayerDatabase
    {
        public const string Dir = Server.Path + "PlayerDB/";

        internal const string uuidRetrieval = "https://api.mojang.com/users/profiles/minecraft/";

        public static PlayerList Players = new();
        
        public static void Load()
        {
            if (!Directory.Exists(Dir))
            {
                Logger.Log("Player DB does not exist. Creating...", LogLevel.Warning);
            }

            foreach (string file in Directory.GetFiles(Dir))
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                Regex regex = new Regex("([a-f0-9]{8}(-[a-f0-9]{4}){4}[a-f0-9]{8})");
                bool isValidUUID = regex.IsMatch(fileName);
                if (!isValidUUID)
                {
                    Logger.Log($"Invalid UUID found in PlayerDB! {fileName} Skipping!", LogLevel.Warning);
                    continue;
                }

                Players.Add(JsonConvert.DeserializeObject<Player>(File.ReadAllText(file)));
            }
        }

        public static void Save()
        {
            foreach (Player player in Players)
            {
                string json = JsonConvert.SerializeObject(player, Formatting.Indented);
                var writer = File.CreateText(Dir + player.UniqueId + ".json");
                writer.WriteLine(json);
                writer.Flush();
                writer.Close();
            }
        }
    }
}
