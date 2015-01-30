using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileCombiner.Contracts
{
	public interface IChunkFileListService
	{
		Task<Queue<Uri>> GetChunkFileList(IConversionMetaData conversionMetaData);

		/// <summary>
		/// Delete this, refactor it into smaller pieces.
		/// </summary>
		/// <param name="conversionMetaData"></param>
		void DoItAll(IConversionMetaData conversionMetaData);
	}
}