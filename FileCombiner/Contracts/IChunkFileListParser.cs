using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileCombiner.Contracts
{
	public interface IChunkFileListParser
	{
		Task<Queue<Uri>> GetChunkFileList(string chunkListUrl, IProgress<int> progressIndicator);
	}
}