using System;
using System.Collections.Generic;

namespace FileCombiner.Contracts
{
	public interface IConversionMetaData
	{
		#region Properties

		Queue<Uri> ParsedChunks { get; set; }

		string ChunkListFileUrl { get; set; }

		int NumberOfChunkFiles { get; set; }

		int PercentDoneChunkFileList { get; set; }

		string TempDirectory { get; set; }

		string UnconvertedFilePath { get; set; }

		string ConvertedFilePath { get; set; }

		bool CanDeleteOldChunkFiles { get; set; }

		bool CanDeleteUnconvertedFile { get; set; }

		#endregion Properties
	}
}