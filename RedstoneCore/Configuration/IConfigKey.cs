namespace Redstone.Core.Configuration
{
    public interface IConfigKey
    {
        /// <summary>
        /// The key, or name of the configuration item.
        /// How the server finds the data.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// The representation of the value as an object.
        /// Allows for easy serialization.
        /// </summary>
        object ValueAsObject();

        /// <summary>
        /// Sets the default value to the key.
        /// </summary>
        void SetDefault();
    }
}
