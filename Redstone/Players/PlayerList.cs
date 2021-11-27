using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Redstone.Configuration;

namespace Redstone.Players
{
    public class PlayerList
    {
        public static int MaxPlayers => Config.MaxPlayers;
        
        public static int Online => Server.Online.Count;
    }

    public class SamplePlayer
    {
        [JsonProperty("name")]
        public string Name = "CopperPenguin96";

        [JsonProperty("id")]
        public string Uuid = "be57c0e9-0832-48a7-9940-2baf96b32f92";
    }
}
