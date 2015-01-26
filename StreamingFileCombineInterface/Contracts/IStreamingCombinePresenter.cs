using FileCombiner;

namespace StreamingFileCombineInterface.Contracts
{
	public interface IStreamingCombinePresenter
	{
		void GetChunkFiles(ConversionMetaData conversionMetaData);
	}
}