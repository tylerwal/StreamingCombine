using FileCombiner.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace FileCombiner.Service
{
	/// <summary>
	/// Class to download the inidivudal Chunk Files.
	/// </summary>
	public class ChunkDownloader : IChunkDownloader
	{
		#region Fields

		private const string _outputStreamFileExtension = ".ts";

		private readonly WebClient _webClient;

		#endregion Fields

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="ChunkDownloader"/> class.
		/// </summary>
		/// <param name="webClient">The web client.</param>
		public ChunkDownloader(WebClient webClient)
		{
			_webClient = webClient;
		}

		#endregion Constructor

		#region IChunkDownloader Members

		/// <summary>
		/// Downloads the indivual chunks files to a directory of choosing.
		/// </summary>
		public void DownloadFileChunks(Queue<Uri> chunkUrls, string tempDirectory, IProgress<int> progressIndicator)
		{
			Directory.CreateDirectory(tempDirectory);

			int numberOfUris = chunkUrls.Count;

			StringBuilder streamingFilePathBuilder = new StringBuilder();

			for (int i = 0; i < numberOfUris; i++)
			{
				Uri currentUri = chunkUrls.Dequeue();

				string filePath = GetIndividualChunkFileName(
					tempDirectory,
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
		/// <param name="tempDirectory">The temporary directory.</param>
		/// <param name="uniqueIteration">the iteration in the for loop</param>
		/// <param name="requiredPadding">The required padding.</param>
		/// <param name="streamingFilePathBuilder">a StringBuilder that is being reused</param>
		/// <returns>
		/// The name of the file.
		/// </returns>
		private string GetIndividualChunkFileName(string tempDirectory, int uniqueIteration, int requiredPadding, StringBuilder streamingFilePathBuilder)
		{
			streamingFilePathBuilder.Clear();
			streamingFilePathBuilder.Append("chunk");
			streamingFilePathBuilder.Append('_');
			streamingFilePathBuilder.Append(uniqueIteration.ToString().PadLeft(requiredPadding, '0'));
			streamingFilePathBuilder.Append(_outputStreamFileExtension);

			return Path.Combine(
				tempDirectory,
				streamingFilePathBuilder.ToString()
				);
		} 

		#endregion Helper Methods
	}
}