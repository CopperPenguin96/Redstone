using Redstone.Core;
using Redstone.Core.Types;
using Redstone.Nbt.Tags;
namespace Redstone.Core.Players.Chatting
{
    public class ObjectText : ChatComponent
    {
        public override string Type => "object";
        public Identifier ID { get; set; }
        public OptValue<int> Count { get; set; }
        public CompoundTag ItemNbt { get; set; } // optional

        public override CompoundTag Nbt
        {
            get
            {
                var tag = new CompoundTag(null!)
                {
                    new StringTag("type", Type),
                    new StringTag("id", ID.ToString())
                };

                if (Count != null && Count.Enabled) tag.Add("count", Count.Value);
                if (ItemNbt != null) tag.Add("nbt", ItemNbt);

                // add style, extra, click/hover events as other components do
                return tag;
            }
        }

        public override void Parse(NbtTag tag)
        {
            if (!(tag is CompoundTag cmp)) throw new RedstoneException("Expected CompoundTag for Object component.");

            if (!cmp.Contains("type", out var typeTag) || typeTag.ValueAsString != Type)
                throw new RedstoneException($"Expected type '{Type}' for Object component, but got '{typeTag?.ValueAsString ?? "null"}'.");

            if (!cmp.Contains("id", out var idTag))
                throw new RedstoneException("Missing 'id' field for Object component.");

            ID = new Identifier(idTag.ValueAsString);

            if (cmp.Contains("count"))
            {
                Count = new OptValue<int>(cmp["count"].ValueAsInt);
            }
            else
            {
                Count = new OptValue<int>();
            }

            if (cmp.Contains("nbt"))
            {
                if (cmp["nbt"] is CompoundTag nbtCmp)
                {
                    ItemNbt = nbtCmp;
                }
                else
                {
                    throw new RedstoneException("Expected 'nbt' to be a CompoundTag.");
                }
            }
        }
    }
}
