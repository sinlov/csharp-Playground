using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo.LinQ.Test
{
    public class LinqDemoTest : BaseTests.BaseTests
    {
        [Fact]
        public void Test_Linq_Take()
        {
            List<int> fullList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9
            };
            List<int> lessList = new List<int>()
            {
                1, 2, 3
            };

            int[] fullTake = fullList.Take(5).ToArray();
            Assert.Equal(5, fullTake.Length);
            Assert.Equal(1, fullTake[0]);
            int[] lessTake = lessList.Take(5).ToArray();
            Assert.Equal(3, lessTake.Length);
            Assert.Equal(1, lessList[0]);
        }

        [Fact]
        public void Test_Linq_Skip_Take()
        {
            List<int> fullList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9
            };
            int[] fL = fullList.Skip(0).Take(5).ToArray();
            Assert.Equal(5, fL.Length);
            Assert.Equal(1, fL[0]);
            int[] sL = fullList.Skip(3).Take(5).ToArray();
            Assert.Equal(5, sL.Length);
            Assert.Equal(4, sL[0]);
            int[] tL = fullList.Skip(8).Take(5).ToArray();
            Assert.Equal(1, tL.Length);
            Assert.Equal(9, tL[0]);
        }


        public LinqDemoTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
        }
    }
}