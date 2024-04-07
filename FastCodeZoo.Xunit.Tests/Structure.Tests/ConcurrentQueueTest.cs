using System.Collections.Concurrent;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo.Structure.Tests
{
    public class ConcurrentQueueTest : BaseTests.BaseTests
    {
        public ConcurrentQueueTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
        }

        [Fact]
        public void Test_basic_use_of_concurrent_queue()
        {
            const int inputCounter = 5;
            const int checkerCounter = inputCounter * 2;
            const int finalCheckMs = 2000;
            const int eachOperatorMs = 100;
            ConcurrentQueue<int?> queue = new ConcurrentQueue<int?>();

            for (int i = 0; i < checkerCounter; i++)
            {
                Task.Run(async () =>
                {
                    await Task.Delay(eachOperatorMs);
                    TLog($"queue.Count TryDequeue: {queue.Count}");
                    if (queue.TryDequeue(out var num))
                    {
                        TLog($"Dequeue first out: {num}");
                        Assert.Equal(inputCounter, num);
                    }
                    else
                    {
                        TLog("not found result first");
                    }
                });
            }

            int input = 0;
            for (int i = 0; i < inputCounter; i++)
            {
                Task.Run(async () =>
                {
                    await Task.Delay(eachOperatorMs);
                    input++;
                    TLog($"Enqueue {input}");
                    queue.Enqueue(input);
                });
            }

            for (int i = 0; i < checkerCounter; i++)
            {
                Task.Run(async () =>
                {
                    await Task.Delay(eachOperatorMs);
                    int? num;
                    TLog($"queue.Count TryDequeue: {queue.Count}");
                    bool result = queue.TryDequeue(out num);
                    if (result)
                    {
                        TLog($"Dequeue next out: {num}");
                        Assert.Equal(inputCounter, num);
                    }
                    else
                    {
                        TLog("not found result next");
                    }
                });
            }

            TLog($"queue.Count after {finalCheckMs} ms");
            Task finalCheckTask = Task.Run(async () =>
            {
                await Task.Delay(finalCheckMs);
                TLog($"queue.Count after: {queue.Count}");
                // Assert.Equal(5, queue.Count);
                return;
            });
            finalCheckTask.Wait();
        }
    }
}