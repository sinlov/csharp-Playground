using System;
using System.IO;
using System.Reflection;
using Xunit.Abstractions;

namespace DataStructure.BasicTests
{
    /// <summary>
    /// must use as
    ///
    /// <code>
    /// InitSelf(MethodBase.GetCurrentMethod());
    /// </code>
    /// 
    /// </summary>
    public abstract class BaseTests : DisposableTests
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
            Console.Out.WriteLine("build demo");
            string version = "1.1.0";
            Console.Out.WriteLine($"build demo version {version}");
        }

        protected string GetProgramRunnerDir()
        {
            return _programRunnerDir;
        }

        /// <summary>
        /// Init Self info
        ///
        /// <code>
        /// InitSelf(MethodBase.GetCurrentMethod());
        /// </code>
        /// 
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

        /// <summary>
        /// must use as
        ///
        /// <code>
        /// InitSelf(MethodBase.GetCurrentMethod());
        /// </code>
        /// 
        /// </summary>
        /// <param name="testOutputHelper"></param>
        public BaseTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;

            TestsFixture();
        }
    }
}