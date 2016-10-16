using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace ZipArchiveExample
{
	class Program
	{
		static void Main(string[] args)
		{
			string directoryToArchive = @"c:\temp\Presentations and materials";
			string archiveFileLocation = @"c:\temp\presentations.zip";

			if (File.Exists(archiveFileLocation))
				File.Delete(archiveFileLocation);


			ArchivePresentationsUsingStreams(directoryToArchive, archiveFileLocation);
			ArchiveImages(directoryToArchive, archiveFileLocation, "Images");

            //write a file directly to the zip file.
			using (var fs = new FileStream(archiveFileLocation, FileMode.Open, FileAccess.ReadWrite))
			{
				using (var updateArchive = new ZipArchive(fs, ZipArchiveMode.Update))
				{
					var readmeEntry = updateArchive.CreateEntry("Readme.txt");
					using (var writer = new StreamWriter(readmeEntry.Open()))
					{
						writer.WriteLine("This zip file contains presentations and resources");
						writer.WriteLine("from 2011.");
					}
				}
			}


			using (var fs = File.OpenRead(archiveFileLocation))
			{
				using (var archive = new ZipArchive(fs, ZipArchiveMode.Read))
				{
					foreach (var zipArchiveEntry in archive.Entries)
					{
						decimal originalSize = (decimal)zipArchiveEntry.Length;
						decimal compressedSize = (decimal)zipArchiveEntry.CompressedLength;
						decimal compressionRatio;
						if (originalSize == 0)
							compressionRatio = 0;
						else
							compressionRatio = Math.Round((1 - (compressedSize / originalSize)) * 100, 0);

						Console.WriteLine("Entry Name: {0}", zipArchiveEntry.Name);
						Console.WriteLine("Full Name: {0}", zipArchiveEntry.FullName);
						Console.WriteLine("Compression Ratio: {0}%", compressionRatio);

						Console.WriteLine();
					}

					archive.Entries.Where(zae => zae.Name.EndsWith(".pptx", true, null))
								   .ToList()
								   .ForEach(zae => zae.ExtractToFile(Path.Combine(@"c:\temp", zae.FullName), true));
				}

			}

			Console.Read();
		}

		private static void ArchivePresentations(string directoryToArchive, string archiveLocation)
		{
			var filesToArchive = Directory.EnumerateFiles(directoryToArchive, "*.ppt*", SearchOption.AllDirectories);

			using (var fs = new FileStream(archiveLocation, FileMode.Create, FileAccess.ReadWrite))
			{
				using (var archive = new ZipArchive(fs, ZipArchiveMode.Create))
				{
					foreach (var filename in filesToArchive)
					{
						archive.CreateEntryFromFile(filename, Path.GetFileName(filename));
					}
				}
			}
		}

		private static void ArchivePresentationsUsingStreams(string directoryToArchive, string archiveFileLocation)
		{
			var filesToArchive = Directory.EnumerateFiles(directoryToArchive, "*.ppt*", SearchOption.AllDirectories);

			using (var fs = new FileStream(archiveFileLocation, FileMode.Create, FileAccess.ReadWrite))
			{
				using (var archive = new ZipArchive(fs, ZipArchiveMode.Create))
				{
					foreach (var filename in filesToArchive)
					{
						//The following is for working with file streams.
						var archiveEntry = archive.CreateEntry(Path.GetFileName(filename));
						using (var filestream = new FileStream(filename,FileMode.Open,FileAccess.Read))
						{
							using (var archiveStream = archiveEntry.Open())
							{
								filestream.CopyTo(archiveStream);
							}
						}

						//Note: The following line of code does the same thing.
						//archive.CreateEntryFromFile(filename, Path.GetFileName(filename));
					}
				}
			}
		}
		private static void ArchiveImages(string directoryToArchive, string archiveLocation, string archiveSubDirectory)
		{
			var imagesToArchive = Directory.EnumerateFiles(directoryToArchive, "*.*", SearchOption.AllDirectories)
										   .Where(fn => fn.EndsWith(".jpg", true, null) || fn.EndsWith(".png", true, null));

			using (var fs = new FileStream(archiveLocation, FileMode.Open, FileAccess.ReadWrite))
			{
				using (var archive = new ZipArchive(fs, ZipArchiveMode.Update))
				{
					foreach (var filename in imagesToArchive)
					{
						archive.CreateEntryFromFile(filename, Path.Combine(archiveSubDirectory, Path.GetFileName(filename)));
					}
				}
			}

		}

	}
}
