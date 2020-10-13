using System;
using System.IO;
using System.Reflection;
using Xunit.Abstractions;

namespace FastCodeZoo.BaseTests
{
    public class BaseTests : DisposableTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        private string _selfClassName;
        private string _programRunnerDir;

        protected void TLog(string message)
        {
            _testOutputHelper.WriteLine($"UnitTest {_selfClassName}: {message}");
        }

        protected void TLogException(Exception ex)
        {
            _testOutputHelper.WriteLine($"UnitTest {_selfClassName}: {ex}");
        }

        protected string GetProgramRunnerDir()
        {
            return _programRunnerDir;
        }

        /// <summary>
        /// Init Self info
        /// </summary>
        /// <param name="currentMethod">MethodBase.GetCurrentMethod()</param>
        protected void InitSelf(MethodBase currentMethod)
        {
            if (currentMethod.DeclaringType != null)
            {
                _selfClassName = currentMethod.DeclaringType.FullName;
            }

            if (string.IsNullOrEmpty(_programRunnerDir))
            {
                var editorPath = System.Environment.GetCommandLineArgs()[0];
                _programRunnerDir = Path.GetDirectoryName(editorPath);
            }
        }

        public BaseTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;

            TestsFixture();
        }
    }
}