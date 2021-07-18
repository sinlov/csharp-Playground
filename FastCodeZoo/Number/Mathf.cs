using System;

namespace FastCodeZoo.Number
{
    public static class Mathf
    {
        public static Int32 FloorToInt(float f)
        {
            return Convert.ToInt32(Math.Floor(f));
        }

        public static Int32 Ceiling2Int(float f)
        {
            return Convert.ToInt32(Math.Ceiling(f));
        }
    }
}