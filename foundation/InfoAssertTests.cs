using System;
using KoanHelpers;
using Xunit;

namespace foundation
{
    public class InfoAssertTests : Koan
    {
        [Koan(1)]
        public void AssertTruth()
        {
            Assert.True(true); //This should be true
        }

        [Koan(2)]
        public void AssertTruthWithMessage()
        {
            Assert.True(true, "This should be true -- Please fix this");
        }

        [Koan(3)]
        public void AssertEquality()
        {
            var expectedValue = 3;
            var actualValue = 1 + 2;
            Assert.True(expectedValue == actualValue);
        }

        [Koan(4)]
        public void ABetterWayOfAssertingEquality()
        {
            var expectedValue = 3;
            var actualValue = 1 + 2;
            Assert.Equal(expectedValue, actualValue);
        }
    }
}