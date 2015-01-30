using System.Threading.Tasks;

using FileCombiner.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace FileCombiner
{
	public class ChunklistFileParser : IParser
	{
		private const char NewLineCharacter = '\n';
		private const char ForwardSlash = '/';
		private const string MetaDataLine = "#EXT";

		private readonly Uri _baseAddress;

		private readonly string _chunkListUrl;

		private readonly WebClient _webClient;
		
		public ChunklistFileParser(string chunkListUrl, WebClient webClient)
		{
			_webClient = webClient;

			_chunkListUrl = chunkListUrl;

			int lastSlashLocation = _chunkListUrl.LastIndexOf(ForwardSlash);
			string baseAddress = _chunkListUrl.Remove(lastSlashLocation + 1);

			_baseAddress = new Uri(baseAddress);
		}

		public async Task<Queue<Uri>> GetChunksInOrder()
		{
			//WebClient webClient = new WebClient();

			string[] allFileLines = _webClient.DownloadString(_chunkListUrl).Split(NewLineCharacter);

			/*Task<string> downloadTask = webClient.DownloadStringTaskAsync(_chunkListUrl);
			
			string completeDocument = await downloadTask;

			string[] allFileLines = completeDocument.Split(NewLineCharacter);*/

			return ProcessUnparsedFileIntoUris(allFileLines);
		}
		
		#region Helper Methods

		private Queue<Uri> ProcessUnparsedFileIntoUris(IEnumerable<string> allFileLines)
		{
			var streamingFileLines = ParseStreamFiles(allFileLines);

			return GetStreamFileUris(streamingFileLines);
		}

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