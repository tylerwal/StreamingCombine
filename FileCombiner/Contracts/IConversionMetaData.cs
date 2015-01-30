using System;
using System.Collections.Generic;

namespace FileCombiner.Contracts
{
	public interface IConversionMetaData
	{
		#region Properties

		string OutputDirectory { get; set; }

		Queue<Uri> ParsedChunks { get; set; }

		string ChunkListFileUrl { get; set; }

		int NumberOfChunkFiles { get; set; }

		int PercentDoneChunkFileList { get; set; }

		string MediaName { get; set; }

		string TempDirectory { get; set; }

		string UnConvertedFilePath { get; set; }

		string ConvertedFilePath { get; set; }

		#endregion Properties

		#region Methods

		string CreateOutputFilePath();

		string GetFilePathCorrectedName();

		#endregion Methods
	}
}