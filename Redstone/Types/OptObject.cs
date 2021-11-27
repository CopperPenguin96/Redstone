using System.Runtime.InteropServices;

namespace Redstone.Types
{
    /// <summary>
    /// The Minecraft Protocol has items called "Opt(Type)"
    /// These types are first represented as a bool.
    /// If that bool is false, nothing else proceeds.
    /// If that bool is true, then the object is written.
    /// It's an "optional" object.
    /// </summary>
    /// <typeparam name="T">The type of the initial object.</typeparam>
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

    public class OptBlockPos : OptObject<Position>
    {
        public Position? Position { get; set; }

        public OptBlockPos(bool enabled, Position value = null!) : base(enabled, value)
        {
        }
    }

    public class OptVarInt : OptObject<VarInt>
    {
        public OptVarInt(bool enabled, [Optional] VarInt value) : base(enabled, value)
        {
        }
    }
}
