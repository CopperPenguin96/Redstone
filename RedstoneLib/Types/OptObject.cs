using System.Runtime.InteropServices;

namespace Redstone.Types
{
    /// <summary>
    /// There are several types in Minecraft called "Opt Type"
    /// These types are represented first as a bool.
    /// If that bool is false, nothing else proceeds.
    /// If that bool is true, then the object is written.
    /// Its an "optional" object
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    public class OptObject<T>
    {
        public bool Enabled { get; set; }

        public T? Value { get; set; }

        public OptObject(bool enabled, [Optional] T value)
        {
            Enabled = enabled;
            if (enabled)
            {
                Value = value;
            }
        }
    }
}
