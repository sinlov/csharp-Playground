using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo.FilePlus.Tests
{
    public class FilePlusTest : BaseTests.BaseTests
    {
        private readonly string _testSourceDir;
        private readonly string _testDestDir;

        [Fact]
        public void Test_Exec_File_Exist()
        {
            TLog($"_testSourceDir: {_testSourceDir}");
            if (File.Exists("whoami"))
            {
                TLog($"cmd [ whoami ] exists");
            }
            else
            {
                TLog($"cmd [ whoami ] not exists");
            }
        }

        [Fact]
        public void Test_CopyDirectorIgnore()
        {
            TLog($"_testSourceDir: {_testSourceDir}");
            TLog($"_testDestDir: {_testDestDir}");
            FilePlus.CopyDirectorIgnore(_testSourceDir, _testDestDir, "^*.meta$", true);
        }

        public FilePlusTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
            _testSourceDir = Path.Combine(GetCurSourceFileAbsDir, "copy-test-source");
            _testDestDir = Path.Combine(GetCurSourceFileAbsDir, "copy-test-dest");
        }

        public static string GetCurSourceFileAbsPath
        {
            get
            {
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(1, true);
                return st.GetFrame(0).GetFileName();
            }
        }

        public static string GetCurSourceFileAbsDir
        {
            get { return Path.GetDirectoryName(GetCurSourceFileAbsPath); }
        }
    }
}