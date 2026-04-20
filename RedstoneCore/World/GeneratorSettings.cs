using Redstone.Core.Utils;
using System.Text.Json.Nodes;

namespace Redstone.Core.World
{
    public class GeneratorSettings : IJsonProvider
    {
        public JsonNode ToJson()
        {
            return "{}"; // todo 
        }

        public override string ToString()
        {
            return ToJson().ToJsonString();
        }

        public static GeneratorSettings Parse(string json)
        {
            return new();
        }

        public void FromJson(string json)
        {
            throw new NotImplementedException();
        }
    }
}
