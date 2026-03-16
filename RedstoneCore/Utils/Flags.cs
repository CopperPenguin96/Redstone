using System.Runtime.CompilerServices;

namespace Redstone.Core.Utils
{
    internal class Flags
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSet(int flags, int flag)
        {
            return (flags & flag) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Set(ref int flags, int flag)
        {
            flags |= flag;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Unset(ref int flags, int flag)
        {
            flags &= ~flag;
        }

        #region Generic flagging

        public static bool IsSet<T>(T flags, T flag) where T : struct, IConvertible
        {
            long flagsValue = flags.ToInt64(null);
            long flagValue = flags.ToInt64(null);

            return (flagsValue & flagValue) != 0;
        }

        public static void Set<T>(ref T flags, T flag) where T : struct, IConvertible
        {
            long flagsValue = flags.ToInt64(null);
            long flagValue = flags.ToInt64(null);

            flags = (T)(object)(flagsValue | flagValue);
        }

        public static void Unset<T>(ref T flags, T flag) where T : struct, IConvertible
        {
            long flagsValue = flags.ToInt64(null);
            long flagValue = flags.ToInt64(null);

            flags = (T)(object)(flagsValue & ~flagValue);
        }

        #endregion
    }
}
