using System;
using System.Globalization;

namespace FastCodeZoo.DateTimeFormat
{
    public static class DateFormatUtil
    {
        /// <summary>
        /// 获取时间戳 秒级
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStampStrSecond()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /// <summary>
        /// 获取时间戳 秒级
        /// </summary>
        /// <returns></returns>
        public static double GetTimeStampSecond()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return ts.TotalSeconds;
        }

        /// <summary>
        /// 获取时间戳 毫秒级
        /// </summary>
        /// <returns></returns>
        public static Int64 TimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return (Int64) ts.TotalMilliseconds;
        }

        /// <summary>
        /// 获取时间戳 毫秒级
        /// </summary>
        /// <returns></returns>
        public static double GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return ts.TotalMilliseconds;
        }

        /// <summary>
        /// 获取时间戳 毫秒级
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStampStr()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        /// <summary>
        /// 得到UTC的格式化时间表示，精确到微秒
        /// </summary>
        public static string GetFormatUTCTime()
        {
            return DateTimeOffset.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        }

        /// <summary>
        /// UNIX时间戳转换成DateTime.ToString，毫秒级
        /// </summary>
        /// <param name="strTimestamp">毫秒级 时间戳</param>
        /// <param name="format">例如 yyyy-MM-dd HH:mm:ss ,如果为空，将使用 <see cref="CultureInfo.InstalledUICulture"/></param>
        /// <returns>To time Zone Info <see cref="TimeZoneInfo.Local"/></returns>
        public static string ConvertUnixTimeStampToString(long strTimestamp, string format = "")
        {
            System.DateTime startTime =
                TimeZoneInfo.ConvertTime(new System.DateTime(1970, 1, 1), TimeZoneInfo.Utc, TimeZoneInfo.Local); // 当地时区
            DateTime dt = startTime.AddMilliseconds(strTimestamp);
            if (string.IsNullOrEmpty(format))
            {
                return dt.ToString(CultureInfo.InstalledUICulture);
            }

            return dt.ToString(format);
        }

        /// <summary>
        /// UNIX时间戳转换成DateTime.ToLongTimeString，毫秒级
        /// <returns>To time Zone Info <see cref="TimeZoneInfo.Local"/></returns>
        /// </summary>
        public static string ConvertUnixTimeStampToDateTimeString(string strTimestamp)
        {
            long lTimestamp = long.Parse(strTimestamp);
            System.DateTime startTime =
                TimeZoneInfo.ConvertTime(new System.DateTime(1970, 1, 1), TimeZoneInfo.Utc, TimeZoneInfo.Local); // 当地时区
            DateTime dt = startTime.AddMilliseconds(lTimestamp);
            return dt.ToLongTimeString();
        }

        /// <summary>
        /// UNIX时间戳转换成DateTime，毫秒级
        /// <returns>To time Zone Info <see cref="TimeZoneInfo.Local"/></returns>
        /// </summary>
        public static DateTime ConvertUnixTimeStampToDateTime(string strTimestamp)
        {
            long lTimestamp = long.Parse(strTimestamp);
            System.DateTime startTime =
                TimeZoneInfo.ConvertTime(new System.DateTime(1970, 1, 1), TimeZoneInfo.Utc, TimeZoneInfo.Local); // 当地时区
            DateTime dt = startTime.AddMilliseconds(lTimestamp);
            return dt;
        }

        /// <summary>
        /// UNIX时间戳转换成DateTime，秒级
        /// <returns>To time Zone Info <see cref="TimeZoneInfo.Local"/></returns>
        /// </summary>
        public static DateTime ConvertUnixTimeStampToDateTimeSecond(string strTimestamp)
        {
            long lTimestamp = long.Parse(strTimestamp);
            System.DateTime startTime =
                TimeZoneInfo.ConvertTime(new System.DateTime(1970, 1, 1), TimeZoneInfo.Utc, TimeZoneInfo.Local); // 当地时区
            DateTime dt = startTime.AddSeconds(lTimestamp);
            return dt;
        }

        /// <summary>
        /// UNIX时间戳转换成DateTime，毫秒级
        /// </summary>
        public static string ConvertUnixTimeStampToDateTimeStringOld(string strTimestamp)
        {
            long lTimestamp = long.Parse(strTimestamp);
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            DateTime dt = startTime.AddMilliseconds(lTimestamp);
            return dt.ToLongTimeString();
        }

        /// <summary>
        /// UNIX时间戳转换成DateTime，毫秒级
        /// </summary>
        public static DateTime ConvertUnixTimeStampToDateTimeOld(string strTimestamp)
        {
            long lTimestamp = long.Parse(strTimestamp);
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            DateTime dt = startTime.AddMilliseconds(lTimestamp);
            return dt;
        }
    }
}