using System;

using FileCombiner.Contracts;
using System.IO;
using System.Net;

using Frapper;

namespace FileCombiner
{
	class CreateFile
	{
		static void Main(string[] args)
		{
			Media media = new Media
			{
				ChunkListFileUrl = @"",
				Name = "",
				OutputDirectory = @"C:\Programming\\"
			};

			IParser chunklistFileParser = new ChunklistFileParser(media.ChunkListFileUrl);
			
			if (!Directory.Exists(media.OutputDirectory))
			{
				Directory.CreateDirectory(media.OutputDirectory);
			}

			WebClient webClient = new WebClient();
			
			ICombiner fileCombiner = new FileCombiner();
			fileCombiner.Initialize(chunklistFileParser, media, webClient);

			FileInfo initialOutputFile = fileCombiner.CreateCombinedFile();

			string unconvertedFileName = initialOutputFile.FullName;

			string convertedFileName = Path.ChangeExtension(unconvertedFileName, ".mkv");

			FFMPEG ffmpeg = new FFMPEG();

			string ffmpegCommand = string.Format("-i {0} -vcodec copy -acodec copy -f matroska {1}", unconvertedFileName, convertedFileName);

			Console.WriteLine("Converting file...\nCommand Executing: {0}", ffmpegCommand);

			string something = ffmpeg.RunCommand(ffmpegCommand);
			
			Console.WriteLine(something);
		}
	}
}
