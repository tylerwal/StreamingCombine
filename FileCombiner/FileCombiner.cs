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

		private IParser _parser;

		private Media _media;

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

		public void Initialize(IParser parser, Media media, WebClient webClient)
		{
			_parser = parser;
			_media = media;
			_webClient = webClient;
		}

		public void CreateCombinedFile()
		{
			DownloadChunkFiles();

			CombineStreamFiles(_media.CreateOutputFileName());
		}

		#endregion ICombiner Methods

		#region Helper Methods

		private void DownloadChunkFiles()
		{
			int numberOfUris = _parser.StreamingFileUris.Count;

			StringBuilder streamingFilePathBuilder = new StringBuilder();

			for (int i = 0; i < numberOfUris; i++)
			{
				Uri currentUri = _parser.StreamingFileUris.Dequeue();

				string filePath = CreateChunkFileName(i, streamingFilePathBuilder);

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

			DirectoryInfo streamFileDirectory = new DirectoryInfo(_media.OutputDirectory);

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

		/// <summary>
		/// Creates the 'small' chunk file names that are incremented by 1.
		/// Output name => %outputDirectory%/Temp/%nameWithoutSpaces%_%padding%%increment$.ts
		/// </summary>
		/// <param name="uniqueIteration">the iteration in the for loop</param>
		/// <param name="streamingFilePathBuilder">a StringBuilder that is being reused</param>
		/// <returns>The name of the file.</returns>
		private string CreateChunkFileName(int uniqueIteration, StringBuilder streamingFilePathBuilder)
		{
			int requiredPadding = 3; //(_parser.StreamingFileUris.Count % 100) + 1;

			streamingFilePathBuilder.Clear();
			streamingFilePathBuilder.Append(_media.OutputDirectory);
			//streamingFilePathBuilder.Append("Temp/");
			streamingFilePathBuilder.Append(_media.GetCleansedName());
			streamingFilePathBuilder.Append('_');
			streamingFilePathBuilder.Append(uniqueIteration.ToString().PadLeft(requiredPadding, '0'));
			streamingFilePathBuilder.Append(_outputStreamFileExtension);
			
			return streamingFilePathBuilder.ToString();
		}
		
		#endregion Helper Methods
	}
}