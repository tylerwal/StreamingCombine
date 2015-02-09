using System;
using System.Collections.Generic;

namespace FileCombiner.Contracts
{
	public interface IChunkFileListParser
	{
		Queue<Uri> GetChunkFileList(string chunkListUrl, IProgress<int> progressIndicator);
	}
}