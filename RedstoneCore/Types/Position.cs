using System.Globalization;

namespace Redstone.Core.Types
{
    public class Position
    {
        private const int X_Bits = 26;
        private const int Y_Bits = 12;
        private const int Z_Bits = 26;

        public int X { get; set; }

        public int Y { get; set; } 

        public int Z { get; set; }

        public Position(long encoded)
        {
            X = (int)(encoded >> 38);
            Z = (int)(encoded << 26 >> 38);
            Y = (int)(encoded << 52 >> 52);
        }

        public static Position Decode(long value)
        {
            return new Position(value);
        }

        public long Encode()
        {
            return (X & 0x3FFFFFF) << 38 | (Z & 0x3FFFFFF) << 12 | Y & 0xFFF;
        }

        public override string ToString()
        {
            // Represent the position as three space-separated coordinates: "X Y Z"
            return $"{X} {Y} {Z}";
        }

        public string ToMinecraftString(PositionFormat format, double? xOffset = null, double? yOffset = null, double? zOffset = null)
        {
            static string FormatNumber(double value)
                => value.ToString(CultureInfo.InvariantCulture);

            switch (format)
            {
                case PositionFormat.Absolute:
                    return ToString();
                case PositionFormat.Relative:
                    {
                        double x = xOffset ?? 0;
                        double y = yOffset ?? 0;
                        double z = zOffset ?? 0;

                        static string fmt(double v) => v == 0 ? "~" : "~" + FormatNumber(v);

                        return $"{fmt(x)} {fmt(y)} {fmt(z)}";
                    }
                case PositionFormat.Local:
                    {
                        if (!xOffset.HasValue || !yOffset.HasValue || !zOffset.HasValue)
                            throw new RedstoneException(new ArgumentException("Local coordinates require all three offsets to be provided."));

                        static string fmtLocal(double v) => v == 0 ? "^" : "^" + FormatNumber(v);

                        return $"{fmtLocal(xOffset.Value)} {fmtLocal(yOffset.Value)} {fmtLocal(zOffset.Value)}";
                    }
                default:
                    throw new RedstoneException(new ArgumentOutOfRangeException(nameof(format), format, null));
            }
        }

    }

    public enum PositionFormat
    {
        Absolute,
        Relative,
        Local
    }
}
