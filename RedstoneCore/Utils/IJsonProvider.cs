namespace Redstone.Core.Utils
{
    public interface IJsonProvider
    {
        string JsonString();

        void FromJson(string json);
    }
}
