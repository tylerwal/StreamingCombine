using FileCombiner.Contracts;
using System;
using System.Threading.Tasks;

namespace StreamingFileCombineInterface.Contracts
{
	public interface IStreamingCombinePresenter
	{
		Task<IConversionMetaData> GetChunkFileList(IConversionMetaData conversionMetaData, Progress<int> progressIndicator);

		void DownloadChunkFiles(IConversionMetaData conversionMetaData);

		void CombineChunkFiles(IConversionMetaData conversionMetaData);

		void ConvertFile(IConversionMetaData conversionMetaData);
	}
}