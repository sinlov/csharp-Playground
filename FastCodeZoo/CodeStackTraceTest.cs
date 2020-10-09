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
            Assert.NotEmpty(CodeStackTrace.GetProgramRunnerDir);
        }

        [Fact]
        public void Test_GetCurSourceFileAbsPath()
        {
            TLog($"CodeStackTrace.GetCurSourceFileAbsPath {CodeStackTrace.GetCurSourceFileAbsPath}");
            Assert.NotEmpty(CodeStackTrace.GetCurSourceFileAbsPath);
        }
        
        [Fact]
        public void Test_GetCurSourceFileAbsDir()
        {
            TLog($"CodeStackTrace.GetCurSourceFileAbsDir {CodeStackTrace.GetCurSourceFileAbsDir}");
            Assert.NotEmpty(CodeStackTrace.GetCurSourceFileAbsDir);
        }

        public CodeStackTraceTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}