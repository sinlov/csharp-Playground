using System;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace DataStructure.BasicTests
{
    public class UnitTest1 : BaseTests
    {
        [Fact]
        public void Test1()
        {
        }

        public UnitTest1(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
        }
    }
}