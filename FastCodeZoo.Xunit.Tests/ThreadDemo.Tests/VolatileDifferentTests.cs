using System.Reflection;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo.Xunit.Tests.ThreadDemo.Tests
{
    public class VolatileDifferentTests : BaseTests.BaseTests
    {
        [Fact]
        public void StartVolatileCheck()
        {
        }

        public VolatileDifferentTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
        }
    }
}