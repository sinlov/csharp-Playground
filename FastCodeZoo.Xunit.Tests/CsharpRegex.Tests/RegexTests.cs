using System.Reflection;
using System.Text.RegularExpressions;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo.Xunit.Tests.CsharpRegex.Tests
{
    public class RegexTests : BaseTests.BaseTests
    {
        [Fact]
        public void Test_Csharp_Package()
        {
            Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z0-9_]*([.][a-zA-Z][a-zA-Z0-9_]*)*$");
            Assert.Matches(regex, "com.a.b.c");
            Assert.Matches(regex, "com.unity.one");
            Assert.Matches(regex, "com.Unity.one_1");
            Assert.Matches(regex, "com.Unity.One");
            Assert.Matches(regex, "com.Unity.aba.d123");
            Assert.Matches(regex, "com.Unity.aba.d123.acf_");
            Assert.DoesNotMatch(regex, "_com.Unity.aba.d123.acf");
            Assert.DoesNotMatch(regex, "Com.Unity._One");
            Assert.DoesNotMatch(regex, "1Com.Unity.1One");
            Assert.DoesNotMatch(regex, "Com.Unity.1One");
        }

        public RegexTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
        }
    }
}