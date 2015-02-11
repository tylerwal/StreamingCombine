using System;
using System.Collections.Generic;
using System.Threading;

namespace FileCombiner.Contracts
{
	public interface IChunkDownloader
	{
		/// <summary>
		/// Downloads the file chunks.
		/// </summary>
		/// <param name="chunkUrls">The chunk urls.</param>
		/// <param name="tempDirectory">The temporary directory.</param>
		/// <param name="progressIndicator">The progress indicator.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		void DownloadFileChunks(Queue<Uri> chunkUrls, string tempDirectory, IProgress<IProgressData> progressIndicator, CancellationToken cancellationToken);
	}
}