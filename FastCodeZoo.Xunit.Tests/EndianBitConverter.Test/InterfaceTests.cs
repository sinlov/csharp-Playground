using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo.EndianBitConverter.Test
{
    public class InterfaceTests : BaseTests.BaseTests
    {
        [Fact]
        public void IsLittleEndian()
        {
            Assert.False(EndianBitConverter.BigEndian.IsLittleEndian);
            Assert.True(EndianBitConverter.LittleEndian.IsLittleEndian);
        }

        public InterfaceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
        }
    }
}