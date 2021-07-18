using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo.DateTimeFormat.Test
{
    public class SecondFormatUtilTest : BaseTests.BaseTests
    {
        [Fact]
        public void Test_FloatTimeFloor2String()
        {
            TLog(SecondFormatUtil.FloatTimeFloor2String(3800f));
            Assert.Equal("0″", SecondFormatUtil.FloatTimeFloor2String(-2f));
            Assert.Equal("2″", SecondFormatUtil.FloatTimeFloor2String(2f));
            Assert.Equal("30″", SecondFormatUtil.FloatTimeFloor2String(30.1f));
            Assert.Equal("01:03′20″", SecondFormatUtil.FloatTimeFloor2String(3800f));
        }

        [Fact]
        public void Test_FloatTimeCeiling2String()
        {
            Assert.Equal("0″", SecondFormatUtil.FloatTimeFloor2String(-2f));
            Assert.Equal("2″", SecondFormatUtil.FloatTimeCeiling2String(2f));
            Assert.Equal("31″", SecondFormatUtil.FloatTimeCeiling2String(30.1f));
            Assert.Equal("01:03′20″", SecondFormatUtil.FloatTimeCeiling2String(3800f));
        }

        public SecondFormatUtilTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
        }
    }
}