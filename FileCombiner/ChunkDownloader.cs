using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

using FileCombiner.Contracts;

namespace FileCombiner
{
	public class ChunkDownloader : IChunkDownloader
	{
		#region Fields

		private const string _outputStreamFileExtension = ".ts";

		private string _tempDirectoryPath;

		private Queue<Uri> _chunkUrls;

		private IConversionMetaData _conversionMetaData;

		private readonly WebClient _webClient;

		#endregion Fields

		#region Constructor

		public ChunkDownloader(WebClient webClient)
		{
			_webClient = webClient;
		}

		#endregion Constructor

		#region IChunkDownloader Members

		/// <summary>
		/// Initializes the specified conversion meta data.
		/// </summary>
		/// <param name="conversionMetaData">The conversion meta data.</param>
		public void Initialize(IConversionMetaData conversionMetaData)
		{
			_chunkUrls = conversionMetaData.ParsedChunks;
			_conversionMetaData = conversionMetaData;
		}

		/// <summary>
		/// Downloads the indivual chunks files to a directory of choosing.
		/// </summary>
		public void DownloadFileChunks()
		{
			Directory.CreateDirectory(_conversionMetaData.TempDirectory);

			int numberOfUris = _chunkUrls.Count;

			StringBuilder streamingFilePathBuilder = new StringBuilder();

			for (int i = 0; i < numberOfUris; i++)
			{
				Uri currentUri = _chunkUrls.Dequeue();

				string filePath = GetIndividualChunkFileName(
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

		#endregion IChunkDownloader Members

		#region Helper Methods

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
		private string GetIndividualChunkFileName(int uniqueIteration, int requiredPadding, StringBuilder streamingFilePathBuilder)
		{
			streamingFilePathBuilder.Clear();
			streamingFilePathBuilder.Append("chunk");
			streamingFilePathBuilder.Append('_');
			streamingFilePathBuilder.Append(uniqueIteration.ToString().PadLeft(requiredPadding, '0'));
			streamingFilePathBuilder.Append(_outputStreamFileExtension);

			return Path.Combine(
				_conversionMetaData.TempDirectory,
				streamingFilePathBuilder.ToString()
				);
		} 

		#endregion Helper Methods
	}
}