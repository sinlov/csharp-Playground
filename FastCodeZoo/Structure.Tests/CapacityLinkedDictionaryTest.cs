using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FakerDotNet;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo.Structure.Tests
{
    public class CapacityLinkedDictionaryTest : BaseTests.BaseTests
    {
        public CapacityLinkedDictionaryTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
        }

        [Fact]
        public void Test_basic()
        {
            const int wantCapacity = 10;

            CDictDemo demo = new CDictDemo(wantCapacity);
            Assert.Equal(0, demo.Count);
            Assert.Equal(wantCapacity, demo.Capacity);

            int keyCnt = 0;

            var firstKey = $"{keyCnt}";
            keyCnt++;
            string firstValue = Faker.Name.Name();
            demo.Set(firstKey, firstValue);
            var secKey = $"{keyCnt}";
            string secValue = Faker.Name.Name();
            demo.Set(secKey, secValue);
            keyCnt++;

            for (int i = 0; i < wantCapacity - 2; i++)
            {
                demo.Set($"{keyCnt}", Faker.Name.Name());
                keyCnt++;
            }

            Assert.Equal(wantCapacity, demo.Count);
            Assert.Equal(wantCapacity, demo.Capacity);

            Assert.True(demo.ContainsKey(firstKey));
            Assert.True(demo.ContainsKey(secKey));

            Assert.Equal(new[]
            {
                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
            }, demo.LinkKeys.ToArray());

            var lastKey = $"{keyCnt}";
            string lastVal = Faker.Name.Name();
            demo.Set(lastKey, lastVal);
            Assert.Equal(wantCapacity, demo.Count);
            Assert.Equal(wantCapacity, demo.Capacity);
            Assert.False(demo.ContainsKey(firstKey));
            Assert.Equal(lastKey, demo.LastKey());
            Assert.Equal(lastVal, demo.LastValue());
            Assert.Equal(secKey, demo.FirstKey());
            Assert.Equal(secValue, demo.FirstValue());
            Assert.Equal(new[]
            {
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
            }, demo.LinkKeys.ToArray());

            Assert.False(demo.Remove("11"));
            Assert.True(demo.Remove("3"));
            Assert.Equal(wantCapacity - 1, demo.Count);
            Assert.Equal(wantCapacity, demo.Capacity);
            Assert.Equal(lastKey, demo.LastKey());
            Assert.Equal(lastVal, demo.LastValue());
            Assert.Equal(secKey, demo.FirstKey());
            Assert.Equal(secValue, demo.FirstValue());
            Assert.Equal(new[]
            {
                "1", "2", "4", "5", "6", "7", "8", "9", "10",
            }, demo.LinkKeys.ToArray());

            demo.Clean();
            Assert.Equal(0, demo.Count);
            Assert.Equal(wantCapacity, demo.Capacity);
        }

        [Fact]
        public void Test_Range()
        {
            const int wantCapacity = 10;

            CDictDemo demo = new CDictDemo(wantCapacity);
            Assert.Equal(0, demo.Count);
            Assert.Equal(wantCapacity, demo.Capacity);

            int keyCnt = 0;
            var firstKey = $"{keyCnt}";
            keyCnt++;
            string firstValue = Faker.Name.Name();
            demo.Set(firstKey, firstValue);
            var secKey = $"{keyCnt}";
            string secValue = Faker.Name.Name();
            demo.Set(secKey, secValue);
            keyCnt++;

            Dictionary<string, string> addRange = new Dictionary<string, string>();
            for (int i = 0; i < wantCapacity - 2; i++)
            {
                addRange[$"{keyCnt}"] = Faker.Name.Name();
                keyCnt++;
            }

            demo.SetRange(addRange);
            Assert.Equal(wantCapacity, demo.Count);
            Assert.Equal(wantCapacity, demo.Capacity);

            Assert.True(demo.ContainsKey(firstKey));
            Assert.True(demo.ContainsKey(secKey));

            Assert.Equal(new[]
            {
                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
            }, demo.LinkKeys.ToArray());

            Dictionary<string, string> nextRange = new Dictionary<string, string>();
            for (int i = 0; i < wantCapacity - 1; i++)
            {
                nextRange[$"{keyCnt}"] = Faker.Name.Name();
                keyCnt++;
            }

            demo.SetRange(nextRange);

            var lastKey = $"{keyCnt}";
            string lastVal = Faker.Name.Name();
            keyCnt++;
            demo.Set(lastKey, lastVal);

            Assert.Equal(wantCapacity, demo.Count);
            Assert.Equal(wantCapacity, demo.Capacity);

            Assert.False(demo.ContainsKey(firstKey));
            Assert.False(demo.ContainsKey(secKey));

            Assert.Equal(lastKey, demo.LastKey());
            Assert.Equal(lastVal, demo.LastValue());

            Dictionary<string, string> thirdRange = new Dictionary<string, string>();
            for (int i = 0; i < wantCapacity; i++)
            {
                thirdRange[$"{keyCnt}"] = Faker.Name.Name();
                keyCnt++;
            }

            demo.SetRange(thirdRange);

            Assert.Equal(wantCapacity, demo.Count);
            Assert.Equal(wantCapacity, demo.Capacity);

            Assert.Equal(new[]
            {
                "20",
                "21",
                "22",
                "23",
                "24",
                "25",
                "26",
                "27",
                "28",
                "29",
            }, demo.LinkKeys.ToArray());
        }

        [Fact]
        public void Test_thread()
        {
            const int wantCapacity = 10;

            CDictDemo demo = new CDictDemo(wantCapacity);
            Assert.Equal(0, demo.Count);
            Assert.Equal(wantCapacity, demo.Capacity);
            int keyCnt = 0;

            const int inputCounter = 5;
            const int checkerCounter = inputCounter * 2;
            const int finalCheckMs = 2000;
            const int eachOperatorMs = 100;
            const int lastOperatorMs = eachOperatorMs + eachOperatorMs;


            for (int i = 0; i < inputCounter; i++)
            {
                Task.Run(async () =>
                {
                    await Task.Delay(eachOperatorMs);
                    keyCnt++;
                    var lastKey = $"{keyCnt}";
                    string lastVal = Faker.Name.Name();
                    demo.Set(lastKey, lastVal);
                });
            }

            for (int i = 0; i < inputCounter; i++)
            {
                Task.Run(async () =>
                {
                    await Task.Delay(eachOperatorMs);
                    keyCnt++;
                    Dictionary<string, string> addRange = new Dictionary<string, string>();
                    for (int j = 0; j < wantCapacity; j++)
                    {
                        addRange[$"{keyCnt}"] = Faker.Name.Name();
                        keyCnt++;
                    }

                    demo.SetRange(addRange);
                });
            }

            for (int i = 0; i < checkerCounter; i++)
            {
                Task.Run(async () =>
                {
                    await Task.Delay(eachOperatorMs);
                    Assert.Equal(wantCapacity, demo.Capacity);
                    Assert.Equal(wantCapacity, demo.Count);
                });
            }

            Task<string> lastTask = Task.Run(async () =>
            {
                await Task.Delay(lastOperatorMs);
                keyCnt++;
                var lastKey = $"{keyCnt}";
                string lastVal = Faker.Name.Name();
                demo.Set(lastKey, lastVal);
                return lastKey;
            });

            Task finalCheckTask = Task.Run(async () =>
            {
                await Task.Delay(finalCheckMs);
                TLog($"demo.Count {demo.Count}");
                // Assert.Equal(wantCapacity, demo.Count);
                Assert.Equal(wantCapacity, demo.Capacity);
                TLog($"keyCnt {keyCnt}");
                TLog($"lastTask.Result {lastTask.Result}");
                Assert.True(demo.ContainsKey(lastTask.Result));
                Assert.Equal(lastTask.Result, demo.LastKey());
            });
            finalCheckTask.Wait();
        }
    }
}