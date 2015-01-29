using FileCombiner.Contracts;
using FileCombiner.Ffmpeg;
using Frapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace FileCombiner
{
	public class ChunkFileCombinerService : IChunkFileCombinerService
	{
		#region Fields

		private WebClient _webClient; 

		#endregion Fields

		#region Constructors


		private ChunkFileCombinerService()
		{
		}

		public ChunkFileCombinerService(WebClient webClient)
		{
			// add webclient to GetFileChunks
			_webClient = webClient;
		}
		
		#endregion Constructors
		
		#region Methods

		public void CreateCombinedFile(ConversionMetaData conversionMetaData)
		{
			Queue<Uri> chunklistFileParser = GetChunkFileList(conversionMetaData).Result;

			if (!Directory.Exists(conversionMetaData.OutputDirectory))
			{
				Directory.CreateDirectory(conversionMetaData.OutputDirectory);
			}

			// take the chunk files and append them together to one combined ts file
			ICombiner fileCombiner = new FileCombiner();
			fileCombiner.Initialize(chunklistFileParser, conversionMetaData, _webClient);
			FileInfo initialOutputFile = fileCombiner.CreateCombinedFile();

			// convert from 'ts' to appropriate file
			string output = ConvertFile(initialOutputFile);

			// delete the unconverted 'ts' file
			DeleteFile(initialOutputFile.FullName);
		}

		public async Task<Queue<Uri>> GetChunkFileList(ConversionMetaData conversionMetaData)
		{
			IParser chunklistFileParser = new ChunklistFileParser(conversionMetaData.ChunkListFileUrl);
			
			return chunklistFileParser.GetChunksInOrder().Result;
		}
		
		#endregion Methods

		#region Helper Methods

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

		#endregion Helper Methods
	}
}
