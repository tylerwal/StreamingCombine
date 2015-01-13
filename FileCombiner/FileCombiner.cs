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

		private IMedia _media;

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

		public void Initialize(IParser parser, IMedia media, WebClient webClient)
		{
			_parser = parser;
			_media = media;
			_webClient = webClient;
		}

		public void CreateCombinedFile()
		{
			_tempDirectoryPath = Path.Combine(_media.OutputDirectory, _tempDirectory);

			DownloadChunkFiles(_tempDirectoryPath);

			CombineStreamFiles(_media.CreateOutputFileName());

			DeleteChunkFiles(_tempDirectoryPath);
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

				if (File.Exists(filePath))
				{
					Console.WriteLine("Skipping File #{0} - Already Found", i);
					continue;
				}
				else
				{
					Console.WriteLine("Downloading File #{0}", i);
				}

				byte[] data = _webClient.DownloadData(currentUri);

				File.WriteAllBytes(filePath, data);
			}
		}

		private void CombineStreamFiles(string outputFilePath)
		{
			if (!Directory.Exists(_media.OutputDirectory))
			{
				throw new DirectoryNotFoundException();
			}

			DirectoryInfo streamFileDirectory = new DirectoryInfo(_tempDirectoryPath);

			FileInfo[] streamFiles = streamFileDirectory.GetFiles();

			List<byte[]> byteArrays = new List<byte[]>(streamFiles.Count());

			foreach (FileInfo streamFile in streamFiles)
			{
				Console.WriteLine("Getting Bytes - {0}", streamFile.Name);
				byteArrays.Add(File.ReadAllBytes(streamFile.FullName));
			}

			Console.WriteLine("Creating concatenated file...");

			CombineByteArrays(byteArrays, outputFilePath);
			
			Console.WriteLine("File Done - {0}", outputFilePath);
		}		
 
		private void CombineByteArrays(IEnumerable<byte[]> byteArrays, string outputFilePath)
		{
			foreach (byte[] byteArray in byteArrays)
			{
				using (FileStream fileStream = new FileStream(outputFilePath, FileMode.Append))
				{
					fileStream.Write(byteArray, 0, byteArray.Length);
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
			streamingFilePathBuilder.Append(_media.GetFilePathCorrectedName());
			streamingFilePathBuilder.Append('_');
			streamingFilePathBuilder.Append(uniqueIteration.ToString().PadLeft(requiredPadding, '0'));
			streamingFilePathBuilder.Append(_outputStreamFileExtension);

			return Path.Combine(
				_media.OutputDirectory, 
				_tempDirectory, 
				streamingFilePathBuilder.ToString()
				);
		}
		
		#endregion Helper Methods
	}
}