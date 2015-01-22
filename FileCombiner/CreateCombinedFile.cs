using System.Net;

using FileCombiner.Contracts;
using FileCombiner.Ffmpeg;
using Frapper;
using System;
using System.IO;

namespace FileCombiner
{
	public class StreamingFileCombiner
	{
		public void CreateCombinedFile(ConversionMetaData conversionMetaData)
		{
			IParser chunklistFileParser = new ChunklistFileParser(conversionMetaData.ChunkListFileUrl);

			if (!Directory.Exists(conversionMetaData.OutputDirectory))
			{
				Directory.CreateDirectory(conversionMetaData.OutputDirectory);
			}

			WebClient webClient = new WebClient();
			
			ICombiner fileCombiner = new FileCombiner();
			fileCombiner.Initialize(chunklistFileParser, conversionMetaData, webClient);

			FileInfo initialOutputFile = fileCombiner.CreateCombinedFile();

			string unconvertedFileName = initialOutputFile.FullName;

			string convertedFileName = Path.ChangeExtension(unconvertedFileName, ".mp4");

			FrapperWrapper frapperWrapper = new FrapperWrapper(new FFMPEG());

			IFfmpegCommand command = new FfmpegConversionCommandBuilder()
				.AddInputFilePath(unconvertedFileName)
				.AddOutputFilePath(convertedFileName)
				.AddBitStreamFilter(BitStreamFilter.AacAdtstoasc)
				.GetCommand();

			string output = frapperWrapper.ExecuteCommand(command);

			Console.WriteLine(output);

			Console.ReadKey();
		}
	}
}
