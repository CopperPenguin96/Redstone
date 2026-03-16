using Redstone.Core.Utils;

namespace Redstone.Core.World
{
    public class GeneratorSettings : IJsonProvider
    {
        public string JsonString()
        {
            return "{}"; // todo 
        }

        public override string ToString()
        {
            return JsonString();
        }

        public static GeneratorSettings Parse(string json)
        {
            return new();
        }
    }
}
