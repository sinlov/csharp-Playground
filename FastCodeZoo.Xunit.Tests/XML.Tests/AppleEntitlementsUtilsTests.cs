using System;
using System.IO;
using System.Reflection;
using FastCodeZoo.XML;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo.XMK.Tests
{
    public class AppleEntitlementsUtilsTests : BaseTests.BaseTests
    {
        private string _entitlementsPath;

        public AppleEntitlementsUtilsTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
            _entitlementsPath = Path.Combine(GetCurSourceFileAbsDir, "default.entitlements");
        }

        [Fact]
        public void Test_AddSignWithApple()
        {
            Exception exception = AppleEntitlementsUtils.AddSignWithApple(_entitlementsPath);
            if (exception != null)
            {
                TLogException(exception);
            }

            Assert.Null(exception);
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