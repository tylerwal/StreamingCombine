using FileCombiner.Contracts;
using System.Threading.Tasks;

namespace StreamingFileCombineInterface.Contracts
{
	public interface IStreamingCombinePresenter
	{
		Task<IConversionMetaData> GetChunkFileList(IConversionMetaData conversionMetaData);

		void DownloadChunkFiles(IConversionMetaData conversionMetaData);

		void CombineChunkFiles(IConversionMetaData conversionMetaData);

		void ConvertFile(IConversionMetaData conversionMetaData);
	}
}