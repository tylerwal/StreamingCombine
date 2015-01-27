using FileCombiner;
using FileCombiner.Contracts;

namespace StreamingFileCombineInterface.Contracts
{
	public interface IStreamingCombinePresenter
	{
		void GetChunkFiles(ref ConversionMetaData conversionMetaData);

		void DoItAll(ConversionMetaData conversionMetaData);
	}
}