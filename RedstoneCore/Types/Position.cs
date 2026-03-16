using System.Globalization;

namespace Redstone.Core.Types
{
    public class Position
    {
        private long _value;
        private const int X_Bits = 26;
        private const int Y_Bits = 12;
        private const int Z_Bits = 26;

        public int[] Coordinates => [X, Y, Z];

        public int X
        {
            get => (int)(_value >> Z_Bits + Y_Bits);
        }

        public int Y
        {
            get
            {
                long y_mask = (1L << Y_Bits) - 1;
                long yVal = _value & y_mask;
                return (int)(yVal | ((yVal & 1L << Y_Bits - 1) != 0 ? ~y_mask : 0));
            }
        }

        public int Z
        {
            get
            {
                long zVal = _value >> Y_Bits;
                long z_mask = (1L << Z_Bits) - 1;
                zVal &= z_mask;
                return (int)(zVal | ((zVal & 1L << Z_Bits - 1) != 0 ? ~z_mask : 0));
            }
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
