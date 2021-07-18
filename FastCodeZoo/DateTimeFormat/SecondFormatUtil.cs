using System.Text;
using FastCodeZoo.Number;

namespace FastCodeZoo.DateTimeFormat
{
    public static class SecondFormatUtil
    {
        /// <summary>
        /// float time to String
        /// </summary>
        /// <param name="time">time float</param>
        /// <returns>like 3800f => 01:03′20″ </returns>
        public static string FloatTimeFloor2String(float time)
        {
            if (time < 0)
            {
                return "0″";
            }

            float h = Mathf.FloorToInt(time / 3600f);
            float m = Mathf.FloorToInt(time / 60f - h * 60f);
            float s = Mathf.FloorToInt(time - m * 60f - h * 3600f);
            StringBuilder sb = new StringBuilder();
            if (h > 0)
            {
                sb.Append(h.ToString("00")).Append(":");
            }

            if (m > 0)
            {
                sb.Append(m.ToString("00")).Append("′");
            }
            else
            {
                if (h > 0)
                {
                    sb.Append("00′");
                }
            }

            if (s > 9)
            {
                sb.Append(s.ToString("00")).Append("″");
            }
            else
            {
                sb.Append(s.ToString("0")).Append("″");
            }

            return sb.ToString();
        }

        /// <summary>
        /// float time to String
        /// </summary>
        /// <param name="time">time float</param>
        /// <returns>like 3800f => 01:03′20″ </returns>
        public static string FloatTimeCeiling2String(float time)
        {
            if (time < 0)
            {
                return "0″";
            }

            float h = Mathf.FloorToInt(Mathf.Ceiling2Int(time) / 3600f);
            float m = Mathf.FloorToInt(Mathf.Ceiling2Int(time) / 60f - h * 60f);
            float s = Mathf.FloorToInt(Mathf.Ceiling2Int(time) - m * 60f - h * 3600f);
            StringBuilder sb = new StringBuilder();
            if (h > 0)
            {
                sb.Append(h.ToString("00")).Append(":");
            }

            if (m > 0)
            {
                sb.Append(m.ToString("00")).Append("′");
            }
            else
            {
                if (h > 0)
                {
                    sb.Append("00′");
                }
            }

            if (s > 9)
            {
                sb.Append(s.ToString("00")).Append("″");
            }
            else
            {
                sb.Append(s.ToString("0")).Append("″");
            }

            return sb.ToString();
        }
    }
}