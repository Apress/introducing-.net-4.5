using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace TaskWhenAllExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new List<Task>();
            tasks.Add(Task.Run(async () =>
                        {
                            var stopwatch = new Stopwatch();
                            stopwatch.Start();
                            await Task.Delay(3000);
                            stopwatch.Stop();
                            Console.WriteLine("Task 1 completed after {0} seconds", stopwatch.Elapsed.Seconds);
                        }));

            tasks.Add(Task.Run(async () =>
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                await Task.Delay(new TimeSpan(0, 0, 2))
                    .ContinueWith(t =>
                      {
                          Console.WriteLine("task 2 Delay completed");
                      });
                stopwatch.Stop();
                Console.WriteLine("Task 2 completed after {0} seconds", stopwatch.Elapsed.Seconds);
            }));
            tasks.Add(Task.Run(async () =>
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                await Task.Delay(1000);
                Thread.Sleep(1000);
                stopwatch.Stop();
                Console.WriteLine("Task 3 completed after {0} seconds", stopwatch.Elapsed.Seconds);
            }));

            var anotherTask = DoSomething(2000);
            anotherTask.ContinueWith(t => Console.WriteLine(t.Result));

            Task.WhenAll(tasks).ContinueWith(t =>
                {
                    Console.WriteLine("All done");
                });

            Console.WriteLine("waiting...");
            Console.Read();



        }

        static async Task<string> DoSomething(int millisecondDelay)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await Task.Delay(millisecondDelay);
            await Task.Run(() => "dummy");
            stopwatch.Stop();

            return string.Format("Do something completed after {0} seconds", stopwatch.Elapsed.Seconds);
        }
    }
}
