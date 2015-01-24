using FileCombiner.Contracts;
using FileCombiner.Ffmpeg;
using Frapper;
using System.IO;
using System.Net;

namespace FileCombiner
{
	public class ChunkFileCombinerService
	{
		public void CreateCombinedFile(ConversionMetaData conversionMetaData)
		{
			IParser chunklistFileParser = GetFileChunks(conversionMetaData);

			if (!Directory.Exists(conversionMetaData.OutputDirectory))
			{
				Directory.CreateDirectory(conversionMetaData.OutputDirectory);
			}

			WebClient webClient = new WebClient();
			
			ICombiner fileCombiner = new FileCombiner();
			fileCombiner.Initialize(chunklistFileParser, conversionMetaData, webClient);

			// take the chunk files and append them together to one combined ts file
			FileInfo initialOutputFile = fileCombiner.CreateCombinedFile();

			// convert from 'ts' to appropriate file
			string output = ConvertFile(initialOutputFile);

			// delete the unconverted 'ts' file
			DeleteFile(initialOutputFile.FullName);
		}

		private static void DeleteFile(string filePath)
		{
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
		}
		
		private static string ConvertFile(FileInfo initialOutputFile)
		{
			string unconvertedFileName = initialOutputFile.FullName;

			string convertedFileName = Path.ChangeExtension(unconvertedFileName, ".mp4");

			FrapperWrapper frapperWrapper = new FrapperWrapper(new FFMPEG());

			IFfmpegCommand command = new FfmpegConversionCommandBuilder()
				.AddInputFilePath(unconvertedFileName)
				.AddOutputFilePath(convertedFileName)
				.AddBitStreamFilter(BitStreamFilter.AacAdtstoasc)
				.GetCommand();

			return frapperWrapper.ExecuteCommand(command);
		}

		private static IParser GetFileChunks(ConversionMetaData conversionMetaData)
		{
			IParser chunklistFileParser = new ChunklistFileParser(conversionMetaData.ChunkListFileUrl);
			return chunklistFileParser;
		}
	}
}
