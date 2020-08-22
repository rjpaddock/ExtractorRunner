using System;
using System.Diagnostics;
using System.IO;
using CommandLine;

namespace ExtractorRunner
{
	class Program
	{
		static void Main(string[] args)
		{
			
			var parsed = Parser.Default.ParseArguments<Options>(args);
			var options = ((Parsed<Options>) parsed).Value;
			
			var extractor_exe_path = "ccextractorwin";
			foreach (var fileName in Directory.GetFiles(options.Directory,$"*{options.Extension}"))
			{
				Console.WriteLine(fileName);
				var process = new Process()
				{
					StartInfo = new ProcessStartInfo
					{
						FileName = $"{extractor_exe_path}",
						Arguments = $"{fileName}",
						UseShellExecute = true,
					}
				};
				process.Start();
			}

		}
		public class Options
		{
			[Option(longName:"extension",HelpText = "Extension of files to convert",Default = ".mpg")]
			public string Extension { get; set; } = "";

			[Option(longName: "directory", HelpText = "Directory to process", Default = ".")]
			public string Directory { get; set; } = ".";
		}
	}
}
