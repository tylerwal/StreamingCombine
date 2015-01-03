using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FileCombiner
{
	class Program
	{
		static void Main(string[] args)
		{
			string chunkListFilePath = @"http://media.strava.com/vod/smil:TheScream.smil/chunklist_w2086349083_b2400000.m3u8?timestamp=1420335686&stream=TheScream&signature=bed48b215c9ddf4653503e9f5ff8c77c467ecd4f00132d732f6fb6af58497968";

			ChunklistFileParser chunklistFileParser = new ChunklistFileParser(chunkListFilePath);

			string outputDirectory = @"C:\Programming\TheLongScream\";
			string outputFilePrepend = "TheLongScream";
			string outputStreamingFileExtension = ".ts";

			string outputCombinedFileExtension = ".ts";

			if (!Directory.Exists(outputDirectory))
			{
				Directory.CreateDirectory(outputDirectory);
			}

			WebClient webClient = new WebClient();

			int numberOfUris = chunklistFileParser.StreamingFileUris.Count;
			
			for (int i = 0; i < numberOfUris; i++)
			{
				Uri currentUri = chunklistFileParser.StreamingFileUris.Dequeue();
				
				StringBuilder streamingFilePathBuilder = new StringBuilder();
				streamingFilePathBuilder.Append(outputDirectory);
				streamingFilePathBuilder.Append(outputFilePrepend);
				streamingFilePathBuilder.Append('_');
				streamingFilePathBuilder.Append(i.ToString().PadLeft(3, '0'));
				streamingFilePathBuilder.Append(outputStreamingFileExtension);

				string filePath = streamingFilePathBuilder.ToString();

				if (File.Exists(filePath))
				{
					Console.WriteLine("Skipping File #{0} - Already Found", i);
					continue;
				}
				else
				{
					Console.WriteLine("Downloading File #{0}", i);
				}

				byte[] data = webClient.DownloadData(currentUri);

				File.WriteAllBytes(filePath, data);
			}

			ChunkCombiner chunkCombiner = new ChunkCombiner(outputDirectory);

			StringBuilder combinedFilePathBuilder = new StringBuilder();
			combinedFilePathBuilder.Append(outputDirectory);
			combinedFilePathBuilder.Append(outputFilePrepend);
			combinedFilePathBuilder.Append(outputCombinedFileExtension);

			chunkCombiner.CombineStreamFiles(combinedFilePathBuilder.ToString());
		}
	}
}
