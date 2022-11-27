using System;
using System.Text;

namespace FastCodeZoo.BaseTests
{
    public static class RandomDataTools
    {
        private static System.Random Random = new System.Random();

        private static readonly char[] CharArr = new[]
        {
            'a', 'b', 'd', 'c', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'p', 'r', 'q', 's', 't', 'u', 'v',
            'w', 'z', 'y', 'x',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Q', 'P', 'R', 'T', 'S', 'V', 'U',
            'W', 'X', 'Y', 'Z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        public static string StringAscii(int n)
        {
            StringBuilder num = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                num.Append(CharArr[Random.Next(0, CharArr.Length)].ToString());
            }

            return num.ToString();
        }

        public static byte[] CharBytes(int n)
        {
            return Encoding.UTF8.GetBytes(StringAscii(n));
        }

        public static int Int32(int max)
        {
            return max > 0 ? Random.Next(0, max) : 0;
        }

        public static long Int64(int max)
        {
            return max > 0 ? Random.Next(0, max) : 0;
        }

        public static uint UInt(int max)
        {
            return max > 0 ? Convert.ToUInt32(Random.Next(0, max)) : 0;
        }

        public static float Float()
        {
            // Not a uniform distribution w.r.t. the binary floating-point number line
            // which makes sense given that NextDouble is uniform from 0.0 to 1.0.
            // Uniform w.r.t. a continuous number line.
            //
            // The range produced by this method is 6.8e38.
            //
            // Therefore if NextDouble produces values in the range of 0.0 to 0.1
            // 10% of the time, we will only produce numbers less than 1e38 about
            // 10% of the time, which does not make sense.
            var result = (Random.NextDouble()
                          * (Single.MaxValue - (double)Single.MinValue))
                         + Single.MinValue;
            return (float)result;
        }

        public static double Double()
        {
            // Not a uniform distribution w.r.t. the binary floating-point number line
            // which makes sense given that NextDouble is uniform from 0.0 to 1.0.
            // Uniform w.r.t. a continuous number line.
            //
            // The range produced by this method is 6.8e38.
            //
            // Therefore if NextDouble produces values in the range of 0.0 to 0.1
            // 10% of the time, we will only produce numbers less than 1e38 about
            // 10% of the time, which does not make sense.
            var result = (Random.NextDouble()
                          * (Single.MaxValue - (double)Single.MinValue))
                         + Single.MinValue;
            return result;
        }

        public static decimal Decimal(int max)
        {
            return new Decimal(Int64(max));
        }
    }
}