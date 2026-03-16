namespace Redstone.Core.Utils
{
    public interface IStaticList<T>
    {
        string Name { get; }

        T Value { get; }
    }
}
