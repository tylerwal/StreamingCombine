using FileCombiner.Contracts;
using System;
using System.Threading.Tasks;

namespace StreamingFileCombineInterface.Contracts
{
	public interface IStreamingCombinePresenter
	{
		Task<IStreamingCombineUiModel> GetChunkFileList(IStreamingCombineUiModel streamingCombineUiModel, Progress<int> progressIndicator);

		void DownloadChunkFiles(IStreamingCombineUiModel streamingCombineUiModel, Progress<int> progressIndicator);

		void CombineChunkFiles(IStreamingCombineUiModel streamingCombineUiModel);

		void ConvertFile(IStreamingCombineUiModel streamingCombineUiModel);
	}
}