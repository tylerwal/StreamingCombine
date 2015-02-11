using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace FileCombiner.Contracts
{
	public interface IChunkFileCombiner
	{
		/// <summary>
		/// Gets the chunk file infos.
		/// </summary>
		/// <param name="chunkFileDirectory">The chunk file directory.</param>
		/// <returns>Collection of chunk files.</returns>
		IEnumerable<FileInfo> GetChunkFileInfos(string chunkFileDirectory);

		/// <summary>
		/// Combines the chunk files.
		/// </summary>
		/// <param name="chunkFiles">The chunk files.</param>
		/// <param name="outputFilePath">The output file path.</param>
		/// <param name="progressIndicator">The progress indicator.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns>
		/// The combined file.
		/// </returns>
		FileInfo CombineChunkFiles(IEnumerable<FileInfo> chunkFiles, string outputFilePath, IProgress<IProgressData> progressIndicator, CancellationToken cancellationToken);
	}
}