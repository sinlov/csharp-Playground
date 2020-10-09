using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo
{
    public class Tests : BaseTests
    {
        [Fact]
        public void Test_Build_Helper()
        {
            string namespaceZoo = "FastCodeZoo";
            string runPath = AppDomain.CurrentDomain.BaseDirectory;
            string assemblyPath = Path.Combine(runPath, $"{namespaceZoo}.dll");
            TLog($"assemblyPath: {assemblyPath}");

            var fetchBuildConfig = BuildHelper.FetchBuildConfig(namespaceZoo);
            TLog($"fetchBuildConfig.Name {fetchBuildConfig.Name}");
            TLog($"fetchBuildConfig.NameSpace {fetchBuildConfig.NameSpace}");
            TLog($"fetchBuildConfig.VersionName {fetchBuildConfig.VersionName}");
            TLog($"fetchBuildConfig.VersionCode {fetchBuildConfig.VersionCode}");
            TLog($"fetchBuildConfig.BuildTime {fetchBuildConfig.BuildTime}");
            Assert.True(true);
        }

        public Tests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}