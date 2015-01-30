using FileCombiner.Contracts;
using System.Threading.Tasks;

namespace StreamingFileCombineInterface.Contracts
{
	public interface IStreamingCombinePresenter
	{
		//void GetChunkFiles(ref ConversionMetaData conversionMetaData);

		Task<IConversionMetaData> GetChunkFileList(IConversionMetaData conversionMetaData);

		void DownloadChunkFiles(IConversionMetaData conversionMetaData);

		void DoItAll(IConversionMetaData conversionMetaData);
	}
}