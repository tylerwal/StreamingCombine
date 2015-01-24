using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using FileCombiner.Contracts;

namespace FileCombiner
{
	public class FileCombiner : ICombiner
	{
		#region Fields

		private const string _outputStreamFileExtension = ".ts";

		private const string _tempDirectory = "Temp/";

		private string _tempDirectoryPath;

		private IParser _parser;

		private IConversionMetaData _conversionMetaData;

		private WebClient _webClient;

		#endregion Fields

		#region Constructor

		public FileCombiner()
		{
		}		 

		#endregion Constructor

		#region Properties

		#endregion Properties

		#region ICombiner Methods

		public void Initialize(IParser parser, IConversionMetaData conversionMetaData, WebClient webClient)
		{
			_parser = parser;
			_conversionMetaData = conversionMetaData;
			_webClient = webClient;
		}

		public FileInfo CreateCombinedFile()
		{
			_tempDirectoryPath = Path.Combine(_conversionMetaData.OutputDirectory, _tempDirectory);

			DownloadChunkFiles(_tempDirectoryPath);

			CombineStreamFiles(_conversionMetaData.CreateOutputFilePath());

			DeleteChunkFiles(_tempDirectoryPath);

			return new FileInfo(_conversionMetaData.CreateOutputFilePath());
		}

		#endregion ICombiner Methods

		#region Helper Methods

		private void DownloadChunkFiles(string tempDirectoryPath)
		{
			int numberOfUris = _parser.StreamingFileUris.Count;

			StringBuilder streamingFilePathBuilder = new StringBuilder();
			
			if (!Directory.Exists(tempDirectoryPath))
			{
				Directory.CreateDirectory(tempDirectoryPath);
			}

			for (int i = 0; i < numberOfUris; i++)
			{
				Uri currentUri = _parser.StreamingFileUris.Dequeue();

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
		}

		private void CombineStreamFiles(string outputFilePath)
		{
			if (!Directory.Exists(_conversionMetaData.OutputDirectory))
			{
				throw new DirectoryNotFoundException();
			}

			DirectoryInfo streamFileDirectory = new DirectoryInfo(_tempDirectoryPath);

			FileInfo[] chunkFiles = streamFileDirectory.GetFiles();
			
			CombineChunkFiles(chunkFiles, outputFilePath);
		}

		private void CombineChunkFiles(IEnumerable<FileInfo> chunkFiles, string outputFilePath)
		{
			foreach (FileInfo chunkFile in chunkFiles)
			{
				using (FileStream fileStream = new FileStream(outputFilePath, FileMode.Append))
				{
					byte[] chunkBytes = File.ReadAllBytes(chunkFile.FullName);

					fileStream.Write(chunkBytes, 0, chunkBytes.Length);
				}
			}
		}

		private void DeleteChunkFiles(string tempDirectoryPath)
		{
			Directory.Delete(tempDirectoryPath, true);
		}

		/// <summary>
		/// Creates the 'small' chunk file names that are incremented by 1.
		/// Output name = %outputDirectory%/Temp/%nameWithoutSpaces%_%padding%%increment$.ts
		/// </summary>
		/// <param name="uniqueIteration">the iteration in the for loop</param>
		/// <param name="requiredPadding">The required padding.</param>
		/// <param name="streamingFilePathBuilder">a StringBuilder that is being reused</param>
		/// <returns>
		/// The name of the file.
		/// </returns>
		private string CreateChunkFileName(int uniqueIteration, int requiredPadding, StringBuilder streamingFilePathBuilder)
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
		}
		
		#endregion Helper Methods
	}
}