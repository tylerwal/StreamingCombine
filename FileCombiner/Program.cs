using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using FileCombiner.Contracts;

namespace FileCombiner
{
	class Program
	{
		static void Main(string[] args)
		{
			Media media = new Media
			{
				ChunkListFileUrl = @"http://media.strava.com/vod/smil:TheScream.smil/chunklist_w775134912_b300000.m3u8?timestamp=1420858556&stream=TheScream&signature=f97ebc28696bb49543c1130d558d075bc1c518a609254f756d0033bf53b39f7b",
				Name = "The Long Scream",
				OutputDirectory = @"C:\Programming\TheLongScreamTestSmall\"
			};

			IParser chunklistFileParser = new ChunklistFileParser(media.ChunkListFileUrl);
			
			if (!Directory.Exists(media.OutputDirectory))
			{
				Directory.CreateDirectory(media.OutputDirectory);
			}

			WebClient webClient = new WebClient();
			
			ICombiner fileCombiner = new FileCombiner();
			fileCombiner.Initialize(chunklistFileParser, media, webClient);

			fileCombiner.CreateCombinedFile();
		}
	}
}
