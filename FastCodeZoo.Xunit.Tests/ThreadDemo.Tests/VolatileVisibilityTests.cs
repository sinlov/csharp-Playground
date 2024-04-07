using System;
using System.Reflection;
using System.Threading;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace FastCodeZoo.Xunit.Tests.ThreadDemo.Tests
{
    public class VolatileVisibility
    {
        private readonly ITestOutputHelper _outLog;

        private void Log(string msg)
        {
            // no currently active test exception in XUnit C#
            try
            {
                _outLog.WriteLine(msg);
            }
            catch
            {
                // ignore
            }
        }

        public VolatileVisibility(ITestOutputHelper testOutputHelper)
        {
            _outLog = testOutputHelper;
        }

        private bool _flag = false;

        public void Biz()
        {
            Thread th = new Thread(Worker);
            th.Start();
            Thread.Sleep(2000);
            _flag = true;
            Log("Flag became true!");
        }


        void Worker()
        {
            _flag = false;
            while (!_flag)
            {
            }

            Log("Done");
        }
    }

    public class VolatileVisibilityTests : BaseTests.BaseTests
    {
        [Fact]
        public void Volatile_Visibility()
        {
            VolatileVisibility vv = new VolatileVisibility(TestOutputHelper);
            vv.Biz();
        }

        public VolatileVisibilityTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
        }
    }
}