using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;


namespace TDFExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var names = new string[] { "alice", "bob", "chris", "david", "elizabeth", "francis", "gary", "harry", "ian" };


            SimpleActionBlockExample(names);
			//SimpleActionBlockExampleWithIncreasedParallelism(names);
            //TransformAndActionBlock(names);
            //JoinBlockExample(names);
            //BufferBlockExample(names);
            Console.Read();
        }

        private static void SimpleActionBlockExample(IEnumerable<string> names)
        {
            var actionBlock = new ActionBlock<string>(async s =>
            {
                await Task.Delay(500);
                Console.WriteLine(s.ToUpper());
            });
			actionBlock.Completion.ContinueWith(t => Console.WriteLine("Block processing is completed"));
                       
            foreach (var name in names)
            {
                actionBlock.Post(name);
            }
            Console.WriteLine("Data queued: {0}", actionBlock.InputCount);

            //loop awhile so we can check the queue count
            while (actionBlock.InputCount > 0) { }
           
            Console.WriteLine("Data queued: {0}", actionBlock.InputCount);
			Thread.Sleep(1000);
			actionBlock.Post("Zac");
            //now set the block to complete 
           // actionBlock.Complete();
            //With the block set to complete it will no longer process messages
            //actionBlock.Post("This message will never be processed");
            
            Console.Read();
        }

        private static void SimpleActionBlockExampleWithIncreasedParallelism(IEnumerable<string> names)
        {
            var dataflowBlockOptions = new ExecutionDataflowBlockOptions
            {
                TaskScheduler = TaskScheduler.Default,
                MaxDegreeOfParallelism = 4
            };

            var actionBlock = new ActionBlock<string>(async s =>
            {
                await Task.Delay(1000);
                Console.WriteLine(s.ToUpper());
            }, dataflowBlockOptions);
            
            foreach (var name in names)
            {
                actionBlock.Post(name);
            }

            Console.WriteLine("Waiting...");
            Console.Read();
        }

    
        private static void TransformAndActionBlock(IEnumerable<string> names)
        {
            var actionBlock = new ActionBlock<string>(async s =>
                {
                    await Task.Delay(500);
                    Console.WriteLine(s);

                });
            var actionBlock2 = new ActionBlock<string>(async s =>
            {
                await Task.Delay(500);
                Console.WriteLine("block 2:{0}",s);

            });

            var toUpperTransformBlock = new TransformBlock<string, string>(s =>
                {
                    return s.ToUpper(); 
                });

            var reverseStringBlock = new TransformBlock<string, string>(async s =>
            {
                await Task.Delay(500);
                return new string(s.Reverse().ToArray());
            });

            toUpperTransformBlock.LinkTo(reverseStringBlock);
            reverseStringBlock.LinkTo(actionBlock);
            reverseStringBlock.LinkTo(actionBlock2);
            foreach (var name in names)
            {
                toUpperTransformBlock.Post(name);

            }

            Console.WriteLine("Waiting...");
            Console.Read();
        }

        private static void BufferBlockExample(IEnumerable<string> names)
        {
            var ActionBlock1 = new ActionBlock<string>(s =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("{0} from action block 1", s);
                }, new ExecutionDataflowBlockOptions { BoundedCapacity = 1 });

            var ActionBlock2 = new ActionBlock<string>(async s =>
            {
                await Task.Delay(800);
                Console.WriteLine("{0} from action block 2", s);
            }, new ExecutionDataflowBlockOptions { BoundedCapacity = 1 });

            var ActionBlock3 = new ActionBlock<string>(async s =>
            {
                await Task.Delay(500);
                Console.WriteLine("{0} from action block 3", s);
            }, new ExecutionDataflowBlockOptions { BoundedCapacity = 1 });

            var bufferblock = new BufferBlock<string>();



            bufferblock.LinkTo(ActionBlock1);
            bufferblock.LinkTo(ActionBlock2);
            bufferblock.LinkTo(ActionBlock3);

            foreach (var name in names)
            {
                bufferblock.Post(name);
                
            }

            Console.WriteLine("waiting...");
            Console.Read();
        }

        private static void JoinBlockExample(IEnumerable<string> names)
        {
            
            var actionBlock = new ActionBlock<Tuple<string, string>>(async s =>
            {
                await Task.Delay(1000);
                Console.WriteLine("{0}:{1}", s.Item1, s.Item2);
            });

          var transformBlock = new TransformBlock<string, string>(s =>
            {
                return s.ToUpper();
            });

            var transformBlock2 = new TransformBlock<string, string>(async s =>
            {
                await Task.Delay(500);
                return new string(s.Reverse().ToArray());
            });

            var joinBlock = new JoinBlock<string, string>();
            joinBlock.LinkTo(actionBlock);

            transformBlock.LinkTo(joinBlock.Target1);
            transformBlock2.LinkTo(joinBlock.Target2);

            var broadcastBlock = new BroadcastBlock<string>(s =>
                {
                    return s;
                });
        
           
            broadcastBlock.LinkTo(transformBlock);
            broadcastBlock.LinkTo(transformBlock2);

            foreach (var name in names)
            {
                broadcastBlock.Post(name);
            }

            Console.WriteLine("Waiting...");

            Console.Read();
        }

     
    }
}
