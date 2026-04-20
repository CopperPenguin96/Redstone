using Redstone.Nbt.Tags;

namespace Redstone.Nbt
{
    /// <summary>
    /// For consistency with objects that produce NBT tags.
    /// </summary>
    public abstract class NbtTagProvider
    {
        public abstract NbtTag Nbt { get; }

        public abstract void Parse(NbtTag tag);
    }
}
