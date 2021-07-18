using System;

namespace FastCodeZoo.Number
{
    public static class NumberConvert
    {
        public static Int32 Float2IntFloor(float f)
        {
            return Convert.ToInt32(Math.Floor(f));
        }

        public static Int32 Float2IntTruncate(float f)
        {
            return Convert.ToInt32(Math.Truncate(f));
        }

        public static Int32 Float2IntCeiling(float f)
        {
            return Convert.ToInt32(Math.Ceiling(f));
        }

        public static Int32 Float2IntRound(float f, MidpointRounding rounding = MidpointRounding.ToEven)
        {
            return Convert.ToInt32(Math.Round(f, rounding));
        }
    }
}