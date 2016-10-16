using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ch03TPLFeatures1C
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessSimpleTasks();
            Console.WriteLine("Waiting...");
            Console.Read();
        }

        private static async void ProcessSimpleTasks()
        {
            var tasks = new List<Task<string>>();

            tasks.Add(SimpleTask("Task 1", 2000));
            tasks.Add(SimpleTask("Task 2", 2000));

            var firstTaskBack = await Task.WhenAny<string>(tasks) ;
          

            Console.WriteLine(firstTaskBack.Result);
        }
        private static async Task<string> SimpleTask(string taskName, int millisecondsDelay)
        {
            await Task.Delay(millisecondsDelay);
            return string.Format("{0} has completed", taskName);
        }
    }
}
