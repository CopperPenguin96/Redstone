using Redstone.Core.Types;

namespace Redstone.World
{
    public sealed class Block(Identifier identifier, int legacyId = 0, byte legacyData = 0)
    {
        public Identifier Identifier { get; } = identifier;

        public int LegacyId { get; } = legacyId;
        public byte LegacyData { get; } = legacyData;

        public Dictionary<string, string> States { get; } = new();

        /// <summary>
        /// Helper to create a block with specific states
        /// </summary>
        public Block WithState(string key, string value)
        {
            States[key] = value;
            return this;
        }

        public override string ToString()
        {
            if (States.Count == 0) return Identifier.ToString();

            return $"{Identifier}[{string.Join(",", States.Select(x => $"{x.Key}={x.Value}"))}]";
        }
    }
}