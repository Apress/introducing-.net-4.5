using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipFileExample
{
	class Program
	{
		static void Main(string[] args)
		{
			var directoryToArchive = @"c:\temp\Presentations and materials";
			var archiveFileLocation = @"c:\temp\presentations.zip";
			var readMeFile = @"c:\temp\readme.txt";

			if (File.Exists(archiveFileLocation))
				File.Delete(archiveFileLocation);

			Console.WriteLine("starting zip");

			ZipFile.CreateFromDirectory(directoryToArchive, archiveFileLocation);
		
			Console.WriteLine("Zip completed");
			Console.WriteLine("Add readme file");
			using (var archive = ZipFile.Open(archiveFileLocation,ZipArchiveMode.Update))
			{
				archive.CreateEntryFromFile(readMeFile, "ReadMe.txt");
			}

			Console.WriteLine("Start Extraction");

			if (Directory.Exists(@"c:\temp\presentations"))
				Directory.Delete(@"c:\temp\presentations", true);

			ZipFile.ExtractToDirectory(archiveFileLocation, @"c:\temp\presentations");
			Console.WriteLine("Extraction completed");
			Console.Read();
		}

	
	}
}
