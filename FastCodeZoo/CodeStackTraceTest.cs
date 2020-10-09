using System;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo
{
    public class CodeStackTraceTest : BaseTests
    {
        [Fact]
        public void Test_GetProgramRunnerPath()
        {
            TLog($"CodeStackTrace.GetProgramRunnerDir {CodeStackTrace.GetProgramRunnerDir}");
        }

        [Fact]
        public void Test_GetCurSourceFileAbsPath()
        {
            TLog($"CodeStackTrace.GetCurSourceFileAbsPath {CodeStackTrace.GetCurSourceFileAbsPath}");
        }

        public CodeStackTraceTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}