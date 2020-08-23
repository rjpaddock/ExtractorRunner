using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using CommandLine;

namespace ExtractorRunner
{
	class Program
	{
		static void Main(string[] args)
		{
			
			var parsed = Parser.Default.ParseArguments<Options>(args);
			var options = ((Parsed<Options>) parsed).Value;
			
			var extractor_exe_path = "";
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
				extractor_exe_path = "ccextractorwin";
			}
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				extractor_exe_path = "ccextractor";
			}
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				extractor_exe_path = "/home/azureuser/data/projects/ccextractor/linux/ccextractor";
			}


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
