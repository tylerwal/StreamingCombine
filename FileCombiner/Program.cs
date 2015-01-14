using FileCombiner.Contracts;
using System.IO;
using System.Net;

using MediaToolkit;
using MediaToolkit.Model;

namespace FileCombiner
{
	class Program
	{
		static void Main(string[] args)
		{
			Media media = new Media
			{
				ChunkListFileUrl = @"http://media.strava.com/vod/smil:TheHunted.smil/chunklist_w1830659387_b2400000.m3u8?timestamp=1421291531&stream=TheHunted&signature=2819938e1423e409e3d3b640d4ad694ccc6da668166e44db4c601e2b0ce44a6d",
				Name = "Sufferfest - The Hunted",
				OutputDirectory = @"C:\Programming\TheHunted\"
			};

			IParser chunklistFileParser = new ChunklistFileParser(media.ChunkListFileUrl);
			
			if (!Directory.Exists(media.OutputDirectory))
			{
				Directory.CreateDirectory(media.OutputDirectory);
			}

			WebClient webClient = new WebClient();
			
			ICombiner fileCombiner = new FileCombiner();
			fileCombiner.Initialize(chunklistFileParser, media, webClient);

			FileInfo initialOutputFile = fileCombiner.CreateCombinedFile();

			MediaFile unconvertedMediaFile = new MediaFile(initialOutputFile.FullName);

			string newFilePath = Path.ChangeExtension(initialOutputFile.FullName, ".mk4");

			MediaFile convertedMediaFile = new MediaFile(newFilePath);

			using (var engine = new Engine())
			{
				engine.Convert(unconvertedMediaFile, convertedMediaFile);
			}
		}
	}
}
