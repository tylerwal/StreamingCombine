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
				ChunkListFileUrl = @"http://media.strava.com/vod/smil:TheScream.smil/chunklist_w632022093_b2400000.m3u8?timestamp=1420854476&stream=TheScream&signature=f30ecf506f41c9e87ae261dde4fc3b4f556b31da95b42d374f615cb344f686fc",
				Name = "The Long Scream",
				OutputDirectory = @"C:\Programming\TheLongScreamTest\"
			};

			IParser chunklistFileParser = new ChunklistFileParser(media.ChunkListFileUrl);
			
			if (!Directory.Exists(media.OutputDirectory))
			{
				Directory.CreateDirectory(media.OutputDirectory);
			}

			WebClient webClient = new WebClient();
			
			FileCombiner fileCombiner = new FileCombiner();
			fileCombiner.Initialize(chunklistFileParser, media, webClient);

			fileCombiner.CreateCombinedFile();
		}
	}
}
