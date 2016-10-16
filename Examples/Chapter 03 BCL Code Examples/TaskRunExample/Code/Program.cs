using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskRunExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Run() can be called with an Action.
            var firstTask = Task.Run(() =>
            {
                Thread.Sleep(1500);
                Console.WriteLine("the first task has completed.");
            });

            //Using Run<T> we can specify the result type.
            var secondTask = Task.Run<string>(() =>
            {
                Thread.Sleep(1000); 
                return "The second task has completed.";
            });

            secondTask.ContinueWith(task => 
                {
                    Console.WriteLine(task.Result);
                });

            //Task.Run implicitly unwraps a task to expose the inner task
            var implicitlyUnwrappedTask = Task.Run( () =>
            {
                Thread.Sleep(1000);
                return  Task.Run(() => "A result from an inner task.");
            });
            implicitlyUnwrappedTask.ContinueWith(t2 => Console.WriteLine(t2.Result));

            //Unlike Task.Run(), when using Factory.StartNew() we need to explicitly unwrap the task
            //to get to the result
            var explicitlyUnwrappedTask = Task.Factory.StartNew( () =>
                    {
                        Thread.Sleep(1000);
                        return  Task.Factory.StartNew(() =>"A result from a second inner task");
                    }).Unwrap();

            explicitlyUnwrappedTask.ContinueWith(task => 
                {
                    Console.WriteLine(task.Result);
                });

                      
            //Can also pass in a cancellation token if required
            var cancellationTokenSource = new CancellationTokenSource();

            Task.Run(() => Thread.Sleep(5000), cancellationTokenSource.Token)
                .ContinueWith(task =>
                    {
                        if (task.IsCanceled)
                            Console.WriteLine("The third task was cancelled.");
                        else
                            Console.WriteLine("The third task has completed.");
                    });

            cancellationTokenSource.Cancel();
            
            Console.WriteLine("Just hanging around waiting");
          
            Console.ReadKey();
           

        }
    }
}
