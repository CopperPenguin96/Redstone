using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Org.BouncyCastle.Math.EC;

namespace ProtocolSharp.Utils
{
    public class ResponseData
    {
        [JsonProperty("description")]
        public NetworkText Description = new NetworkText { text = "Welcome!" };

        [JsonProperty("players")]
        public PlayerStatusList Players { get; set; }

        [JsonProperty("version")]
        public ResponseVersion Version { get; set; }

        [JsonProperty("favicon")]
        public string Icon { get; set; }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public override string ToString()
        {
            return GetJson();
        }

        public void Save()
        {
            var writer = File.CreateText("jsondata.txt");
            writer.WriteLine(GetJson());
            writer.Flush();
            writer.Close();
        }
    }

    public struct ResponseVersion
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("protocol")]
        public int Protocol;

        public ResponseVersion(string name, int pro)
        {
            Name = name;
            Protocol = pro;
        }
    }

    public struct NetworkText
    {
        public string text;
    }


    public class PlayerStatusList
    {
        public class SamplePlayer
        {
            public SamplePlayer()
            {

            }

            public SamplePlayer(string name, string id)
            {
                Name = name;
                Id = id;
            }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }
        }

        public PlayerStatusList()
        {
            OnlinePlayers = 1;
            SamplePlayer p = new SamplePlayer
            {
                Name = "alexpotter96",
                Id = JavaUUID.Generate("alexpotter96".ToBytes()).ToString()
            };
            Players = new[] { p };
        }

        [JsonProperty("max")]
        public int MaxPlayers => 20;

        [JsonProperty("online")]
        public int OnlinePlayers { get; set; }

        [JsonProperty("sample")]
        public SamplePlayer[] Players { get; set; }
    }
}
