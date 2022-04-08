using System.Reflection;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo.Algorithm.Test
{
    public class ObjectIdTest : BaseTests.BaseTests
    {
        [Fact]
        public void Test_GenObjectID()
        {
            ObjectId newObjectId = ObjectId.NewObjectId();
            Assert.NotEqual("", newObjectId.ToString());
        }

        private void GenObjectID()
        {
            ObjectId newObjectId = ObjectId.NewObjectId();
            Assert.NotEqual("", newObjectId.ToString());
        }

        [Fact]
        public void Test_ObjectId()
        {
            int cnt = 10000;
            for (int i = 0; i < cnt; i++)
            {
                Thread thread = new Thread(new ThreadStart(GenObjectID));
                thread.Start();
            }
        }


        public ObjectIdTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
        }
    }
}