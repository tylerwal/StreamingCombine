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
		
		public Uri BaseAddress
		{
			get;
			set;
		}

		public Queue<Uri> StreamingFileUris
		{
			get;
			set;
		}

		public ChunklistFileParser(FileInfo inputFile, string baseAddress)
		{
			BaseAddress = new Uri(baseAddress);

			var allFileLines = File.ReadLines(inputFile.FullName);

			ProcessUnparsedFileIntoUris(allFileLines);
		}

		public ChunklistFileParser(string chunkListUrl)
		{
			int lastSlashLocation = chunkListUrl.LastIndexOf(ForwardSlash);
			string baseAddress = chunkListUrl.Remove(lastSlashLocation + 1);

			BaseAddress = new Uri(baseAddress);

			WebClient webClient = new WebClient();

			var allFileLines = webClient.DownloadString(chunkListUrl).Split(NewLineCharacter);
			
			ProcessUnparsedFileIntoUris(allFileLines);
		}

		#region Helper Methods

		private void ProcessUnparsedFileIntoUris(IEnumerable<string> allFileLines)
		{
			var streamingFileLines = ParseStreamFiles(allFileLines);

			StreamingFileUris = GetStreamFileUris(streamingFileLines);
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

				Uri combinedUri = new Uri(BaseAddress, trimmedLine);

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