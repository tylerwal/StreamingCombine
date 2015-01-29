using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace FileCombiner.Contracts
{
	public interface ICombiner
	{
		void Initialize(Queue<Uri> chunkUrls, IConversionMetaData conversionMetaData, WebClient webClient);

		void DownloadFileChunks(string temporaryDirectory);

		FileInfo CreateCombinedFile();
	}
}