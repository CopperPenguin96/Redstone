using Redstone.Core.Types;
using Redstone.Nbt.Tags;
namespace Redstone.Players.Chatting
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
    }
}
