using System.IO;

namespace FileCombiner.Contracts
{
	public interface IFileCombinerService
	{
		void Initialize(IConversionMetaData conversionMetaData);

		void DownloadFileChunks();

		FileInfo CreateCombinedFile();
	}
}