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

        public override void Parse(NbtTag tag)
        {
            if (!(tag is CompoundTag cmp))
            {
                throw new ArgumentException("Expected CompoundTag");
            }

            if (!cmp.Contains("type", out var typeTag) || typeTag.ValueAsString != Type)
            {
                throw new ArgumentException($"Expected type '{Type}'");
            }

            if (!cmp.Contains("score", out var scoreTag) || !(scoreTag is CompoundTag scoreCmp))
            {
                throw new ArgumentException("Expected 'score' CompoundTag");
            }

            if (!scoreCmp.Contains("name", out var nameTag) || !scoreCmp.Contains("objective", out var objectiveTag))
            {
                throw new ArgumentException("Expected 'name' and 'objective' StringTags");
            }

            Name = nameTag.ValueAsString;
            Objective = objectiveTag.ValueAsString;
        }
    }

    
}
