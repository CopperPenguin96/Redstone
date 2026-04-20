using Redstone.Core;
using Redstone.Core.Types;
using Redstone.Nbt.Tags;

namespace Redstone.Core.Players.Chatting
{
    public class NbtText : ChatComponent
    {
        public override string Type => "nbt";

        public OptValue<NbtSource> Source { get; set; }

        public NbtTag Tag { get; set; }

        public OptValue<bool> Interpret { get; set; }

        public OptValue<ChatComponent> Seperator = new(Parse("{text: \", \"}"));

        public Selector TargetEntity { get; set; }

        public Position BlockPos { get; set; }

        public Identifier Storage { get; set; }

        public override CompoundTag Nbt
        {
            get
            {
                CompoundTag tag = new(null!)
                {
                    new StringTag("type", Type)
                };

                if (Source != null && Source.Enabled)
                {
                    tag.Add("source", Source.Value.Value);
                }

                tag.Add("nbt", Tag.NbtPath);

                if (Interpret != null && Interpret.Enabled)
                {
                    tag.Add("interpret", Interpret.Value);
                }

                if (Seperator != null && Seperator.Enabled)
                {
                    tag.Add("separator", (CompoundTag)Seperator.Value.Nbt);
                }

                tag.Add("entity", TargetEntity.ToString());
                tag.Add("block", BlockPos.ToString());
                tag.Add("storage", Storage.ToString());

                return tag;
            }
        }

        public override void Parse(NbtTag tag)
        {
            if (!(tag is CompoundTag compound))
            {
                throw new RedstoneException("Expected a compound tag for NbtText");
            }

            if (!compound.Contains("type", out NbtTag typeTag) || typeTag.ValueAsString != Type)
            {
                throw new RedstoneException($"Expected type to be '{Type}' for NbtText");
            }

            if (compound.Contains("source", out NbtTag sourceTag))
            {
                Source = new(NbtSource.Parse(sourceTag.ValueAsString));
            }

            if (compound.Contains("nbt", out NbtTag nbtTag))
            {
                Tag = new StringTag(null!, nbtTag.ValueAsString);
            }
            else
            {
                throw new RedstoneException("Missing 'nbt' tag for NbtText");
            }

            if (compound.Contains("interpret", out NbtTag interpretTag))
            {
                Interpret = new(interpretTag.ValueAsBool);
            }

            if (compound.Contains("separator", out NbtTag separatorTag))
            {
                Seperator = new(Parse(((CompoundTag)separatorTag).ToString()));
            }

            if (!compound.Contains("entity", out NbtTag entityTag))
            {
                throw new RedstoneException("Missing 'entity' tag for NbtText");
            }

            if (!compound.Contains("block", out NbtTag blockTag))
            {
                throw new RedstoneException("Missing 'block' tag for NbtText");
            }

            if (!compound.Contains("storage", out NbtTag storageTag))
            {
                throw new RedstoneException("Missing 'storage' tag for NbtText");
            }

            TargetEntity = Selector.Parse(entityTag.ValueAsString);
            BlockPos = Position.Parse(blockTag.ValueAsString);
            Storage = Identifier.Parse(storageTag.ValueAsString);
        }
    }

    public sealed class NbtSource
    {
        public static readonly NbtSource Block = new("block");
        public static readonly NbtSource Entity = new("entity");
        public static readonly NbtSource Sotrage = new("storage");

        public string Value { get; }

        private NbtSource(string value)
        {
            Value = value;
        }

        public override string ToString() => Value;

        public static bool operator ==(NbtSource? a, NbtSource? b) => ReferenceEquals(a, b);
        public static bool operator !=(NbtSource? a, NbtSource? b) => !ReferenceEquals(a, b);

        public override bool Equals(object? obj) => ReferenceEquals(this, obj);
        public override int GetHashCode() => Value.GetHashCode();

        public static NbtSource Parse(string value) => value.ToLower() switch
        {
            "block" => Block,
            "entity" => Entity,
            "storage" => Sotrage,
            _ => throw new RedstoneException($"Unknown nbt source: {value}")
        };
    }
}


