using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskWhenAnyExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSimpleTasks();

            Console.WriteLine("Waiting...");
            Console.Read();
        }

        private static async void RunSimpleTasks()
        {
            var tasks = new List<Task<string>>();
         
            tasks.Add(SimpleTask("Task 1", 2000));
            tasks.Add(SimpleTask("Task 2", 3000));
            tasks.Add(SimpleTask("Task 3", 4000));
            tasks.Add(SimpleTask("Task 4", 2000));

            while (tasks.Count > 0)
            {
                Task<string> task = await Task.WhenAny<string>(tasks);

                tasks.Remove(task);
                Console.WriteLine(task.Result);
            }
        }
        private static async Task<string> SimpleTask(string taskName, int millisecondsDelay)
        {
            await Task.Delay(millisecondsDelay);
            return string.Format("{0} has completed", taskName);
        }
    }
}
