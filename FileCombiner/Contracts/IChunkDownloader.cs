using System;
using System.Collections.Generic;
using System.Threading;

namespace FileCombiner.Contracts
{
	public interface IChunkDownloader
	{
		void DownloadFileChunks(Queue<Uri> chunkUrls, string tempDirectory, IProgress<int> progressIndicator, CancellationToken cancellationToken);
	}
}