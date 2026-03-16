using Redstone.Core.Utils;

namespace Redstone.Core.Types
{
    public sealed class Selector : IStaticList<char>
    {
        public static readonly Selector NearestPlayer = new('p', "@p");
        public static readonly Selector RandomPlayer = new('r', "@r");
        public static readonly Selector AllPlayers = new('a', "@a");
        public static readonly Selector AllEntities = new('e', "@e");
        public static readonly Selector ExecutingEntity = new('s', "@s");
        public static readonly Selector NearestEntity = new('n', "@n");
       

        public char Value { get; }
        public string Name { get; }

        private Selector(char value, string name)
        {
            Value = value;
            Name = name;
        }

        public override string ToString() => Name;

        public static Selector Parse(string value) => value.ToLower() switch
        {
            "@p" => NearestPlayer,
            "@r" => RandomPlayer,
            "@a" => AllPlayers,
            "@e" => AllEntities,
            "@s" => ExecutingEntity,
            "@n" => NearestEntity,
            _ => throw new ArgumentException($"Invalid selector: {value}")
        };
    }
}
