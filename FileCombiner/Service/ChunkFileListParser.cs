using System.Threading.Tasks;

using FileCombiner.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace FileCombiner.Service
{
	public class ChunkFileListParser : IChunkFileListParser
	{
		#region Fields

		private const char NewLineCharacter = '\n';
		private const char ForwardSlash = '/';
		private const string MetaDataLine = "#EXT";

		private Uri _baseAddress;
		private readonly WebClient _webClient; 

		#endregion Fields

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ChunkFileListParser"/> class.
		/// </summary>
		/// <param name="webClient">The web client.</param>
		public ChunkFileListParser(WebClient webClient)
		{
			_webClient = webClient;
		}
		
		#endregion Constructors
		
		#region Methods

		/// <summary>
		/// Gets the chunk file list.
		/// </summary>
		/// <param name="chunkListUrl">The chunk list URL.</param>
		/// <param name="progressIndicator">The progress indicator.</param>
		/// <returns></returns>
		/*public async Task<Queue<Uri>> GetChunkFileList(string chunkListUrl, IProgress<int> progressIndicator)
		{
			int lastSlashLocation = chunkListUrl.LastIndexOf(ForwardSlash);
			string baseAddress = chunkListUrl.Remove(lastSlashLocation + 1);

			_baseAddress = new Uri(baseAddress);

			progressIndicator.Report(75);

			string[] allFileLines = _webClient.DownloadString(chunkListUrl).Split(NewLineCharacter);

			/*Task<string> downloadTask = webClient.DownloadStringTaskAsync(_chunkListUrl);
			
			string completeDocument = await downloadTask;

			string[] allFileLines = completeDocument.Split(NewLineCharacter);#1#

			return ProcessUnparsedFileIntoUris(allFileLines);
		}*/
		public Queue<Uri> GetChunkFileList(string chunkListUrl, IProgress<int> progressIndicator)
		{
			progressIndicator.Report(0);

			int lastSlashLocation = chunkListUrl.LastIndexOf(ForwardSlash);
			string baseAddress = chunkListUrl.Remove(lastSlashLocation + 1);

			_baseAddress = new Uri(baseAddress);

			Task<string> downloadTask = _webClient.DownloadStringTaskAsync(chunkListUrl);

			string chunkFileList = downloadTask.Result;

			string[] allFileLines = chunkFileList.Split(NewLineCharacter);

			progressIndicator.Report(100);

			return ProcessUnparsedFileIntoUris(allFileLines);
		}
		
		#endregion Methods

		#region Helper Methods

		/// <summary>
		/// Processes the unparsed file into uris.
		/// </summary>
		/// <param name="allFileLines">All file lines.</param>
		/// <returns>A colllection of lines contained within in the Chunk File.</returns>
		private Queue<Uri> ProcessUnparsedFileIntoUris(IEnumerable<string> allFileLines)
		{
			var streamingFileLines = ParseStreamFiles(allFileLines);

			return GetStreamFileUris(streamingFileLines);
		}

		/// <summary>
		/// Gets the stream file uris.
		/// </summary>
		/// <param name="streamingFileLines">The streaming file lines.</param>
		/// <returns>The collection of Uri's parsed from the input lines.</returns>
		private Queue<Uri> GetStreamFileUris(IEnumerable<string> streamingFileLines)
		{
			Queue<Uri> orderedStreamFileUris = new Queue<Uri>();

			foreach (string streamingFileLine in streamingFileLines)
			{
				string trimmedLine = streamingFileLine.Trim();

				if (string.IsNullOrWhiteSpace(trimmedLine))
				{
					continue;
				}

				Uri combinedUri = new Uri(_baseAddress, trimmedLine);

				orderedStreamFileUris.Enqueue(combinedUri);
			}

			return orderedStreamFileUris;
		}

		/// <summary>
		/// Removes the metadata in M3U files.
		/// Files that start with #EXT are not relevant.
		/// </summary>
		/// <param name="unparsedLines">Collection of unparsed lines that could contain metadata as well as streaming file urls.</param>
		/// <returns>Just the streaming file url lines.</returns>
		private IEnumerable<string> ParseStreamFiles(IEnumerable<string> unparsedLines)
		{
			return unparsedLines.Where(i => !i.StartsWith(MetaDataLine));
		}

		#endregion Helper Methods
	}
}
