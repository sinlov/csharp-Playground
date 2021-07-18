using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo.Number.Tests
{
    public class NumberConvertTest : BaseTests.BaseTests
    {
        [Fact]
        public void Test_Float2IntCeiling()
        {
            float f = 0.1f;
            int i = NumberConvert.Float2IntCeiling(f);
            Assert.Equal(1, i);
            Assert.Equal(1, NumberConvert.Float2IntCeiling(0.9f));
            Assert.Equal(1, NumberConvert.Float2IntCeiling(0.1f));
            Assert.Equal(-123, NumberConvert.Float2IntCeiling(-123.55f));
            Assert.Equal(124, NumberConvert.Float2IntCeiling(123.55f));
        }

        [Fact]
        public void Test_Float2IntTruncate()
        {
            float f = 0.1f;
            int i = NumberConvert.Float2IntTruncate(f);
            Assert.Equal(0, i);
            Assert.Equal(-123, NumberConvert.Float2IntTruncate(-123.55f));
            Assert.Equal(123, NumberConvert.Float2IntTruncate(123.55f));
        }

        [Fact]
        public void Test_Float2IntFloor()
        {
            float f = 0.1f;
            int i = NumberConvert.Float2IntFloor(f);
            Assert.Equal(0, i);
            Assert.Equal(-124, NumberConvert.Float2IntFloor(-123.55f));
            Assert.Equal(123, NumberConvert.Float2IntFloor(123.55f));
        }

        [Fact]
        public void Test_Float2IntRound()
        {
            Assert.Equal(0, NumberConvert.Float2IntRound(0.1f));
            Assert.Equal(1, NumberConvert.Float2IntRound(0.9f));
            Assert.Equal(0, NumberConvert.Float2IntRound(0.5f));
            Assert.Equal(2, NumberConvert.Float2IntRound(1.9f));
            Assert.Equal(2, NumberConvert.Float2IntRound(1.5f));
            Assert.Equal(-124, NumberConvert.Float2IntRound(-123.55f));
            Assert.Equal(124, NumberConvert.Float2IntRound(123.55f));
        }

        public NumberConvertTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
        }
    }
}