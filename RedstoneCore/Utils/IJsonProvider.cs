using System.Text.Json.Nodes;

namespace Redstone.Core.Utils
{
    public interface IJsonProvider
    {
        JsonNode ToJson();

        void FromJson(string json);

        public string ToJsonString()
        {
            return ToJson().ToString();
        }
    }
}
