namespace FileCombiner.Contracts
{
	public interface IChunkFileCombinerService
	{
		IParser GetFileChunks(ConversionMetaData conversionMetaData);
	}
}