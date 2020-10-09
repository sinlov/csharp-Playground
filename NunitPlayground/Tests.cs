using System;
using NUnit.Framework;

namespace NunitPlayground
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Console.Out.WriteLine("NUnit test case start");
            Assert.True(true);
        }
    }
}