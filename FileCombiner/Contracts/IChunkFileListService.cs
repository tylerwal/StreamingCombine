using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileCombiner.Contracts
{
	public interface IChunkFileListService
	{
		Task<Queue<Uri>> GetChunkFileList(IConversionMetaData conversionMetaData);
	}
}