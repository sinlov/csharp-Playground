using System;

namespace FastCodeZoo.BaseTests
{
    public abstract class DisposableTests : IDisposable
    {
        public void TestsFixture()
        {
            // Do "global" initialization here; Called before every test method.
        }

        public void Dispose()
        {
            // Do "global" teardown here; Called after every test method.
        }
    }
}