using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppDomainCulture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var culture = CultureInfo.CreateSpecificCulture("ja-JP");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            //Comment out the next two lines to emulate pre .NET 4.5 behaviour
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Action randomCurrency = () =>
                {
                    Console.WriteLine();
                    Console.WriteLine("Current Culture:\t{0}",
                      Thread.CurrentThread.CurrentCulture);
                    Console.WriteLine("Current UI Culture:\t{0}",
                      Thread.CurrentThread.CurrentUICulture);

                    Console.Write("Random currency: ");
                    var rand = new Random();
                    
                    for (int i = 0; i <= 2; i++)
                        Console.Write("\t{0:C2}\t", rand.NextDouble());

                    Console.WriteLine();
                };
            //Call the randomCurrency action on the current thread
            randomCurrency();

            //now run the same action on another thread
            Task.Run(randomCurrency);

            Console.Read();
        }
    }
}
