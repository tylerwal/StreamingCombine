using FileCombiner.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FileCombiner
{
	public class ChunklistFileParser : IParser
	{
		#region Fields

		private const char NewLineCharacter = '\n';
		private const char ForwardSlash = '/';
		private const string MetaDataLine = "#EXT";

		private readonly Uri _baseAddress;
		private readonly string _chunkListUrl;
		private readonly WebClient _webClient; 

		#endregion Fields

		#region Constructor

		public ChunklistFileParser(string chunkListUrl, WebClient webClient)
		{
			_webClient = webClient;

			_chunkListUrl = chunkListUrl;

			int lastSlashLocation = _chunkListUrl.LastIndexOf(ForwardSlash);
			string baseAddress = _chunkListUrl.Remove(lastSlashLocation + 1);

			_baseAddress = new Uri(baseAddress);
		} 

		#endregion Constructor

		#region IParserMethods

		public async Task<Queue<Uri>> GetChunksInOrder()
		{
			//WebClient webClient = new WebClient();

			string[] allFileLines = _webClient.DownloadString(_chunkListUrl).Split(NewLineCharacter);

			/*Task<string> downloadTask = webClient.DownloadStringTaskAsync(_chunkListUrl);
			
			string completeDocument = await downloadTask;

			string[] allFileLines = completeDocument.Split(NewLineCharacter);*/

			return ProcessUnparsedFileIntoUris(allFileLines);
		} 

		#endregion IParserMethods
		
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