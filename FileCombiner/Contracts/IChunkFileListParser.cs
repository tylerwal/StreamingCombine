using System;
using System.Collections.Generic;

namespace FileCombiner.Contracts
{
	public interface IChunkFileListParser
	{
		/// <summary>
		/// Gets the chunk file list.
		/// </summary>
		/// <param name="chunkListUrl">The chunk list URL.</param>
		/// <param name="progressIndicator">The progress indicator.</param>
		/// <returns>A queue of uri's.</returns>
		Queue<Uri> GetChunkFileList(string chunkListUrl, IProgress<IProgressData> progressIndicator);
	}
}