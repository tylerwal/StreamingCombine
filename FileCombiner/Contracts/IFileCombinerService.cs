using System.Collections.Generic;
using System.IO;

namespace FileCombiner.Contracts
{
	public interface IFileCombinerService
	{
		FileInfo[] GetChunkFileInfos(string chunkFileDirectory);

		FileInfo CombineChunkFiles(IEnumerable<FileInfo> chunkFiles, string outputFilePath);

		//void Initialize(IConversionMetaData conversionMetaData);

		//FileInfo CreateCombinedFile();
	}
}