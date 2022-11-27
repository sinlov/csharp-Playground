using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo.LinQPlus.Test
{
    public class SearchPlusTest : BaseTests.BaseTests
    {
        [Fact]
        public void Test_BinarySearchMemberIndex()
        {
            List<SearchItem> testList = new List<SearchItem>()
            {
                new SearchItem("a"),
                new SearchItem("b"),
                new SearchItem("c"),
                new SearchItem("d"),
                new SearchItem("f"),
                new SearchItem("g"),
            };

            int pos = 0;
            int index = SearchPlus.BinarySearchMemberIndex(testList, "e", 0, testList.Count, ref pos);
            Assert.Equal(-1, index);
            Assert.Equal(4, pos);
            index = SearchPlus.BinarySearchMemberIndex(testList, "b", 0, testList.Count, ref pos);
            Assert.Equal(1, index);
            Assert.Equal(1, pos);

            List<SearchItem> reList = testList.ToList();
            reList.Sort(
                (s1, s2) =>
                    String.Compare(s2.Name, s1.Name, StringComparison.Ordinal)
            );

            int rPos = 0;
            int rIndex = SearchPlus.BinarySearchMemberIndex(reList, "e", 0, testList.Count, ref rPos, true);
            Assert.Equal(-1, rIndex);
            Assert.Equal(2, rPos);
            rIndex = SearchPlus.BinarySearchMemberIndex(reList, "b", 0, testList.Count, ref rPos, true);
            Assert.Equal(4, rIndex);
            Assert.Equal(4, rPos);
        }


        public SearchPlusTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
        }
    }
}