using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgressClassExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var directoryToReadFrom = @"c:\temp";
            Console.WriteLine("Start");
            var progress = new Progress<Tuple<string, decimal>>(r =>
                {
                    Console.Clear();
                    Console.WriteLine("percentage done: {0}%", r.Item2);
                    Console.WriteLine(r.Item1);
                });
            var progress2 = new Progress<Tuple<string, decimal>>();
            progress2.ProgressChanged += Progress2_ProgressChanged;
           
            var result = GetFilesAsync(directoryToReadFrom,progress2);

            result.ContinueWith(t =>
                {
                    Console.WriteLine("Done!");
                    progress2.ProgressChanged -= Progress2_ProgressChanged;
                }
                    );
            Console.ReadKey();
        }

        static void Progress2_ProgressChanged(object sender, Tuple<string, decimal> e)
        {
            Console.Clear();
            Console.WriteLine("percentage done: {0}%", e.Item2);
            Console.WriteLine(e.Item1);
        }


        private async static Task GetFilesAsync(string startDirectory, IProgress<Tuple<string, decimal>> progress)
        {
            var files = Directory.GetFiles(startDirectory, "*.*", SearchOption.AllDirectories);
            var tasks = new List<Task<string>>();

            var counter = 0;
            foreach (var fileName in files)
            {
                var fileNameOnly = Path.GetFileName(fileName);
                await GetFileAsync(fileName);
                counter++;
                decimal percentageDone = Math.Round(((decimal)counter / (decimal)files.Length) * 100, 2);
                progress.Report(new Tuple<string, decimal>(fileNameOnly, percentageDone));
            }

        }

        private async static Task<string> GetFileAsync(string fileName)
        {
            var unicodeEncoding = new UnicodeEncoding();
            byte[] result;
            await Task.Delay(50);
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                result = new Byte[stream.Length];
                var readTask = await stream.ReadAsync(result, 0, (int)stream.Length);
            }
            return unicodeEncoding.GetString(result);
        }

    }
}
