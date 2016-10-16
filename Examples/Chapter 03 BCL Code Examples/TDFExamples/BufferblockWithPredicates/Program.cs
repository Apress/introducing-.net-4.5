using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Text.RegularExpressions;

namespace BufferblockWithPredicates
{
	class Program
	{
		static void Main(string[] args)
		{

			bool exit = false;
			var redAction = new ActionBlock<string>(v =>
			{
				var consolecolour = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine(v);
				Console.ForegroundColor = consolecolour;
			}
			);
			var greenAction = new ActionBlock<string>(v =>
			{
				var consolecolour = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.DarkGreen;
				Console.WriteLine(v);
				Console.ForegroundColor = consolecolour;
			}
			);

			var blockoptions = new DataflowBlockOptions { BoundedCapacity = 100 };
			var InputBuffer = new BufferBlock<string>(blockoptions);

			InputBuffer.LinkTo(redAction, input =>
				{
					var regex = new Regex("^[a-h].", RegexOptions.IgnoreCase);
					return regex.IsMatch(input);
				}
				);

			InputBuffer.LinkTo(greenAction, input =>
			{
                var regex = new Regex("^[i-z].",  RegexOptions.IgnoreCase);
				return regex.IsMatch(input);
			}
			);


			while (!exit)
			{
				var input = Console.ReadLine();
				exit = input.Equals("quit", StringComparison.InvariantCultureIgnoreCase);
			
				if (!exit)
				{
					foreach (var word in Splitter(input))
					{
						InputBuffer.Post(word);
					}
					
				}

			}
			Console.Clear();
			Console.WriteLine("Program finished");
			Console.ReadKey();
			
		
		}

		private static IEnumerable<string> Splitter(string input)
		{
			var stringArray = input.Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries);
			foreach (var word in stringArray)
			{
				yield return word;
			}
		}
	}
}
