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
			string outputFileExtension = ".ts";

			if (!Directory.Exists(outputDirectory))
			{
				Directory.CreateDirectory(outputDirectory);
			}

			WebClient webClient = new WebClient();

			int numberOfUris = chunklistFileParser.StreamingFileUris.Count;
			
			for (int i = 0; i < numberOfUris; i++)
			{
				Console.WriteLine("Downloading File #{0}", i);

				var currentUri = chunklistFileParser.StreamingFileUris.Dequeue();

				StringBuilder pathBuilder = new StringBuilder();
				pathBuilder.Append(outputDirectory);
				pathBuilder.Append(outputFilePrepend);
				pathBuilder.Append('_');
				pathBuilder.Append(i);
				pathBuilder.Append(outputFileExtension);

				byte[] data = webClient.DownloadData(currentUri);

				File.WriteAllBytes(pathBuilder.ToString(), data);
			}
		}
	}
}
