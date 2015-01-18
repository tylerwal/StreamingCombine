using FileCombiner.Contracts;
using System.IO;
using System.Net;

using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;

namespace FileCombiner
{
	class CreateFile
	{
		static void Main(string[] args)
		{
			Media media = new Media
			{
				ChunkListFileUrl = @"",
				Name = "",
				OutputDirectory = @"C:\Programming\\"
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

			return;

			string fileName = @"C:\Programming\TheHunted\Sufferfest-TheHunted.ts";

			MediaFile unconvertedMediaFile = new MediaFile(fileName);

			string newFilePath = Path.ChangeExtension(fileName, ".mk4");

			MediaFile convertedMediaFile = new MediaFile(newFilePath);
			
			var conversionOptions = new ConversionOptions
			{
				VideoSize = VideoSize.Hd720,
				AudioSampleRate = AudioSampleRate.Hz44100
			};

			using (var engine = new Engine())
			{
				engine.GetMetadata(unconvertedMediaFile);

				engine.Convert(unconvertedMediaFile, convertedMediaFile, conversionOptions);
			}
		}
	}
}
