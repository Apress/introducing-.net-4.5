using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ConcurrentExclusiveSchedulerPairExample
{
	class Program
	{
		static volatile int valueToChange;
		static void Main(string[] args)
		{
			var schedulerPair = new ConcurrentExclusiveSchedulerPair();
			var cts = new CancellationTokenSource();

			var readExecutionOptions = new ExecutionDataflowBlockOptions
			{
				TaskScheduler = schedulerPair.ConcurrentScheduler,
				CancellationToken = cts.Token,
				MaxDegreeOfParallelism = 3
			};

			var lockExecutionOptions = new ExecutionDataflowBlockOptions
			{
				TaskScheduler = schedulerPair.ExclusiveScheduler,
				CancellationToken = cts.Token
			};

			var readAction = new ActionBlock<string>(s => Console.WriteLine("{0}-{1}", s, valueToChange),
													   readExecutionOptions);
			
			var updateAction = new ActionBlock<int>(i =>
			{
				Console.WriteLine("Updating the value");
				Thread.Sleep(2000);
				valueToChange += i;
				Console.WriteLine("value has been changed");
			}, lockExecutionOptions);

			Console.WriteLine("Press any key to send an update message.\nPress Enter to end processing");
			
			Task.Run(() => SendMessagesToReadActionBlock(readAction, "Reader1", 50), cts.Token);
					
			var hasPressedEnterKey = false;

			while (!hasPressedEnterKey)
			{
				var keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.Enter)
                {
                    cts.Cancel();
                    hasPressedEnterKey = true;
                }
                else
                    Console.WriteLine(Environment.NewLine);
					updateAction.Post(3);
			}
			
			Console.WriteLine("Test finished. Press any key to quit");
			Console.ReadKey();
		}

		private static async void SendMessagesToReadActionBlock(ITargetBlock<string> actionBlock, string message, int counter)
		{
			for (int i = 0; i < counter; i++)
			{
				actionBlock.Post(string.Format("{0}:{1}", message, Thread.CurrentThread.ManagedThreadId));
				await Task.Delay(500);
			}
		}
	}
}
