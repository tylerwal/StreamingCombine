using FileCombiner.Contracts;
using System;
using System.Threading.Tasks;

namespace StreamingFileCombineInterface.Contracts
{
	public interface IStreamingCombinePresenter
	{
		Task<IStreamingCombineUiModel> GetChunkFileList(IStreamingCombineUiModel streamingCombineUiModel, IProgress<int> progressIndicator);

		Task DownloadChunkFiles(IStreamingCombineUiModel streamingCombineUiModel, IProgress<int> progressIndicator);

		void CombineChunkFiles(IStreamingCombineUiModel streamingCombineUiModel);

		void ConvertFile(IStreamingCombineUiModel streamingCombineUiModel);
	}
}