using System;
using System.Threading.Tasks;

namespace StreamingFileCombineInterface.Contracts
{
	public interface IStreamingCombinePresenter
	{
		/// <summary>
		/// Gets the chunk file list.
		/// </summary>
		/// <param name="streamingCombineUiModel">The streaming combine UI model.</param>
		/// <param name="progressIndicator">The progress indicator.</param>
		/// <returns>The view model.</returns>
		Task<IStreamingCombineUiModel> GetChunkFileList(IStreamingCombineUiModel streamingCombineUiModel, IProgress<int> progressIndicator);

		/// <summary>
		/// Downloads the chunk files.
		/// </summary>
		/// <param name="streamingCombineUiModel">The streaming combine UI model.</param>
		/// <param name="progressIndicator">The progress indicator.</param>
		/// <returns>A void task.</returns>
		Task DownloadChunkFiles(IStreamingCombineUiModel streamingCombineUiModel, IProgress<int> progressIndicator);

		/// <summary>
		/// Combines the chunk files.
		/// </summary>
		/// <param name="streamingCombineUiModel">The streaming combine UI model.</param>
		/// <param name="progressIndicator">The progress indicator.</param>
		void CombineChunkFiles(IStreamingCombineUiModel streamingCombineUiModel, IProgress<int> progressIndicator);

		/// <summary>
		/// Converts the file.
		/// </summary>
		/// <param name="streamingCombineUiModel">The streaming combine UI model.</param>
		/// <param name="progressIndicator">The progress indicator.</param>
		void ConvertFile(IStreamingCombineUiModel streamingCombineUiModel, IProgress<int> progressIndicator);

		/// <summary>
		/// Cancels the download chunks.
		/// </summary>
		void CancelDownloadChunks();

		/// <summary>
		/// Cancels the combine chunks.
		/// </summary>
		void CancelCombineChunks();
	}
}