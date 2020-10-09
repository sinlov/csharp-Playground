using Xunit.Abstractions;

namespace FastCodeZoo
{
    public class BaseTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        protected void TLog(string message)
        {
            _testOutputHelper.WriteLine(message);
        }

        public BaseTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
    }
}