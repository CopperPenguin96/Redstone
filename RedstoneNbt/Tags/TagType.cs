namespace Redstone.Nbt.Tags
{
    public enum TagType : byte
    {
        End = 0,
        Byte = 1,
        Boolean = 1, // Unofficial tag for storing boolean values as bytes (0 for false, 1 for true)
        Short = 2,
        Int = 3,
        Long = 4,
        Float = 5,
        Double = 6,
        ByteArray = 7,
        String = 8,
        List = 9,
        Compound = 10,
        IntArray = 11,
        LongArray = 12
    }
}
