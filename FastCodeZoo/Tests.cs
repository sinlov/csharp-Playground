using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo
{
    public class Tests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public Tests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Test_Build_Helper()
        {
            string namespaceZoo = "FastCodeZoo";
            string runPath = AppDomain.CurrentDomain.BaseDirectory;
            string assemblyPath = Path.Combine(runPath, $"{namespaceZoo}.dll");
            _testOutputHelper.WriteLine($"assemblyPath: {assemblyPath}");

            var fetchBuildConfig = BuildHelper.FetchBuildConfig(namespaceZoo);
            _testOutputHelper.WriteLine($"fetchBuildConfig.Name {fetchBuildConfig.Name}");
            _testOutputHelper.WriteLine($"fetchBuildConfig.NameSpace {fetchBuildConfig.NameSpace}");
            _testOutputHelper.WriteLine($"fetchBuildConfig.VersionName {fetchBuildConfig.VersionName}");
            _testOutputHelper.WriteLine($"fetchBuildConfig.VersionCode {fetchBuildConfig.VersionCode}");
            _testOutputHelper.WriteLine($"fetchBuildConfig.BuildTime {fetchBuildConfig.BuildTime}");
            Assert.True(true);
        }
    }
}