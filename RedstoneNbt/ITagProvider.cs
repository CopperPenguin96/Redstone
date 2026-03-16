using Redstone.Nbt.Tags;

namespace Redstone.Nbt
{
    /// <summary>
    /// For consistency with objects that produce NBT tags.
    /// </summary>
    public interface ITagProvider
    {
        NbtTag Nbt { get; }
    }
}
