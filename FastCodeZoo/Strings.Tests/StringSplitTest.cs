using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo.Strings.Tests
{
    public class StringSplitTest : BaseTests.BaseTests
    {
        [Fact]
        public void Test_SplitByCount()
        {
            string[] res = StringSplit.SplitByCount("123:113", ':', 2);
            Assert.Equal(2, res.Length);
            res = StringSplit.SplitByCount("123:113:123", ':', 2);
            Assert.Equal(2, res.Length);
            res = StringSplit.SplitByCount("123:113:123", ':', 3);
            Assert.Equal(3, res.Length);
            res = StringSplit.SplitByCount("123", ':', 1);
            Assert.Equal(1, res.Length);
            res = StringSplit.SplitByCount("123", ':', 2);
            Assert.Equal(1, res.Length);
            res = StringSplit.SplitByCount("", ':', 2);
            Assert.Equal(1, res.Length);
        }

        public StringSplitTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
        }
    }
}