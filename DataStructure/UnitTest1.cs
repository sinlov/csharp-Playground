using System;
using System.Reflection;
using DataStructure.BasicTests;
using Xunit;
using Xunit.Abstractions;

namespace DataStructure
{
    public class UnitTest1 : BaseTests
    {
        [Fact]
        public void Test1()
        {
            TLog("test UnitTest1");
        }

        public UnitTest1(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
        }
    }
}