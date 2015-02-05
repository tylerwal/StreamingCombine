using FileCombiner.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace FileCombiner
{
	public class FileCombinerService : IFileCombinerService
	{
		#region Fields

		public const string OUTPUT_STREAM_FILE_EXTENSION = ".ts";

		//private const string _tempDirectory = "Temp/";

		//private string _tempDirectoryPath;

		/*private Queue<Uri> _chunkUrls;*/

		/*private IConversionMetaData _conversionMetaData;*/

		#endregion Fields

		#region Constructor

		/*public FileCombinerService(WebClient webClient)
		{
			_webClient = webClient;
		}*/

		#endregion Constructor

		#region ICombiner Methods

		/*public void Initialize(IConversionMetaData conversionMetaData)
		{
			_conversionMetaData = conversionMetaData;
		}*/

		/*// REFACTOR THIS OUT
		public FileInfo CreateCombinedFile()
		{
			//DownloadChunkFiles(_tempDirectoryPath);

			GetChunkFileInfos(_conversionMetaData.CreateOutputFilePath());

			DeleteChunkFiles(_tempDirectoryPath);

			return new FileInfo(_conversionMetaData.CreateOutputFilePath());
		}*/

		#endregion ICombiner Methods

		#region Helper Methods

/*		// REFACTOR THIS OUT
		private void DownloadChunkFiles(string tempDirectoryPath)
		{
			int numberOfUris = _chunkUrls.Count;

			StringBuilder streamingFilePathBuilder = new StringBuilder();
			
			if (!Directory.Exists(tempDirectoryPath))
			{
				Directory.CreateDirectory(tempDirectoryPath);
			}

			for (int i = 0; i < numberOfUris; i++)
			{
				Uri currentUri = _chunkUrls.Dequeue();

				string filePath = CreateChunkFileName(
					i, 
					numberOfUris.ToString().Length, 
					streamingFilePathBuilder
					);
				
				try
				{
					byte[] data = _webClient.DownloadData(currentUri);
					File.WriteAllBytes(filePath, data);
				}
				catch (Exception)
				{
					Console.WriteLine("Exception caught");
				}
			}
		}*/

		public IEnumerable<FileInfo> GetChunkFileInfos(string chunkFileDirectory)
		{
			DirectoryInfo streamFileDirectory = new DirectoryInfo(chunkFileDirectory);

			return streamFileDirectory.GetFiles();
			
			//CombineChunkFiles(chunkFiles, outputFilePath);
		}

		public FileInfo CombineChunkFiles(IEnumerable<FileInfo> chunkFiles, string outputFilePath)
		{
			foreach (FileInfo chunkFile in chunkFiles)
			{
				using (FileStream fileStream = new FileStream(outputFilePath, FileMode.Append))
				{
					byte[] chunkBytes = File.ReadAllBytes(chunkFile.FullName);

					fileStream.Write(chunkBytes, 0, chunkBytes.Length);
				}
			}

			return new FileInfo(outputFilePath);
		}

		private void DeleteChunkFiles(string tempDirectoryPath)
		{
			Directory.Delete(tempDirectoryPath, true);
		}

		// REFACTOR THIS OUT!!
		/*private string CreateChunkFileName(int uniqueIteration, int requiredPadding, StringBuilder streamingFilePathBuilder)
		{
			streamingFilePathBuilder.Clear();
			streamingFilePathBuilder.Append(_conversionMetaData.GetFilePathCorrectedName());
			streamingFilePathBuilder.Append('_');
			streamingFilePathBuilder.Append(uniqueIteration.ToString().PadLeft(requiredPadding, '0'));
			streamingFilePathBuilder.Append(_outputStreamFileExtension);

			return Path.Combine(
				_conversionMetaData.OutputDirectory, 
				_tempDirectory, 
				streamingFilePathBuilder.ToString()
				);
		}*/
		
		#endregion Helper Methods
	}
}