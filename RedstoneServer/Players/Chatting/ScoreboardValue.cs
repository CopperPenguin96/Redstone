using Redstone.Nbt.Tags;

namespace Redstone.Core.Players.Chatting
{
    public class ScoreboardValue : ChatComponent
    {
        public override string Type => "score";

        public string Name { get; set; }

        public string Objective { get; set; }

        public ScoreboardValue(string name, string objective)
        {
            Name = name;
            Objective = objective;
        }

        public override CompoundTag Nbt
        {
            get
            {
                return new(null!)
                {
                    new StringTag("type", Type),
                    new CompoundTag("score")
                    {
                        new StringTag("name", Name),
                        new StringTag("objective", Objective)
                    }
                };
            }
        }
    }

    
}
