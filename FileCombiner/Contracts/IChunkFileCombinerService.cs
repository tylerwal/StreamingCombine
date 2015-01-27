namespace FileCombiner.Contracts
{
	public interface IChunkFileCombinerService
	{
		IParser GetFileChunks(ConversionMetaData conversionMetaData);

		/// <summary>
		/// Delete this, refactor it into smaller pieces.
		/// </summary>
		/// <param name="conversionMetaData"></param>
		void CreateCombinedFile(ConversionMetaData conversionMetaData);
	}
}