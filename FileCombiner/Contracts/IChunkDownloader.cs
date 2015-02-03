namespace FileCombiner.Contracts
{
	public interface IChunkDownloader
	{
		void Initialize(IConversionMetaData conversionMetaData);

		void DownloadFileChunks();
	}
}