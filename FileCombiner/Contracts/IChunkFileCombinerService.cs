using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileCombiner.Contracts
{
	public interface IChunkFileCombinerService
	{
		Task<Queue<Uri>> GetChunkFileList(ConversionMetaData conversionMetaData);

		/// <summary>
		/// Delete this, refactor it into smaller pieces.
		/// </summary>
		/// <param name="conversionMetaData"></param>
		void CreateCombinedFile(ConversionMetaData conversionMetaData);
	}
}