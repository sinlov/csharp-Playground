using System;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo.DateTimeFormat.Test
{
    public class DateFormatUtilTest : BaseTests.BaseTests
    {
        private readonly string _nowTimeStamp;
        private string _timeStampStrSecond;

        public DateFormatUtilTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
            _nowTimeStamp = DateFormatUtil.GetTimeStampStr();
            TLog($"_nowTimeStamp      : {_nowTimeStamp}");
            _timeStampStrSecond = DateFormatUtil.GetTimeStampStrSecond();
            TLog($"_timeStampStrSecond: {_timeStampStrSecond}");
        }

        [Fact]
        public void Test_TimeStamp()
        {
            Int64 timeStamp = DateFormatUtil.TimeStamp();
            TLog($"timeStamp: {timeStamp}");
            Assert.NotSame(0, timeStamp);
            string unixTimeStampToString = DateFormatUtil.ConvertUnixTimeStampToString(timeStamp);
            TLog($"unixTimeStampToString: {unixTimeStampToString}");
            Assert.NotNull(unixTimeStampToString);
            string timeStampToString = DateFormatUtil.ConvertUnixTimeStampToString(timeStamp, "yyyy-MM-dd HH:mm:ss");
            TLog($"timeStampToString: {timeStampToString}");
            Assert.NotNull(timeStampToString);
        }

        [Fact]
        public void Test_GetFormatUTCTime()
        {
            string formatUtcTime = DateFormatUtil.GetFormatUTCTime();
            TLog($"formatUtcTime: {formatUtcTime}");
            Assert.NotEmpty(formatUtcTime);
        }

        [Fact]
        public void Test_ConvertUnixTimeStampToDateTime()
        {
            DateTime dateTime = DateFormatUtil.ConvertUnixTimeStampToDateTime(_nowTimeStamp);
            TLog($"ConvertUnixTimeStampToDateTime .ToLongDateString: {dateTime.ToLongDateString()}");
            TLog($"ConvertUnixTimeStampToDateTime .ToLongTimeString: {dateTime.ToLongTimeString()}");
        }

        [Fact]
        public void Test_ConvertUnixTimeStampToDateTimeOld()
        {
            DateTime dateTime = DateFormatUtil.ConvertUnixTimeStampToDateTimeOld(_nowTimeStamp);
            TLog($"ConvertUnixTimeStampToDateTimeOld .ToLongDateString: {dateTime.ToLongDateString()}");
            TLog($"ConvertUnixTimeStampToDateTimeOld .ToLongTimeString: {dateTime.ToLongTimeString()}");
        }

        [Fact]
        public void Test_ConvertUnixTimeStampToDateTimeSecond()
        {
            DateTime dateTime = DateFormatUtil.ConvertUnixTimeStampToDateTimeSecond(_timeStampStrSecond);
            TLog($"ConvertUnixTimeStampToDateTimeOld .ToLongDateString: {dateTime.ToLongDateString()}");
            TLog($"ConvertUnixTimeStampToDateTimeOld .ToLongTimeString: {dateTime.ToLongTimeString()}");
        }
    }
}