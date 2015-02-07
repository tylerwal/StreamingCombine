using FileCombiner;
using FileCombiner.Contracts;
using FileCombiner.Ffmpeg;
using Frapper;
using StreamingFileCombineInterface.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace StreamingFileCombineInterface
{
	public class StreamingCombineViewPresenter : IStreamingCombinePresenter
	{
		#region Fields

		private IStreamingCombineView _streamingCombineView;

		private readonly IChunkFileListService _chunkFileListService;
		private readonly IFileCombinerService _fileCombinerService;
		private readonly IChunkDownloader _chunkDownloader;
		
		#endregion Fields

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="StreamingCombineViewPresenter"/> class.
		/// </summary>
		/// <param name="view">The view.</param>
		public StreamingCombineViewPresenter(IStreamingCombineView view)
		{
			_streamingCombineView = view;

			WebClient webClient = new WebClient();

			_chunkFileListService = new ChunkFileListService(webClient);
			_chunkDownloader = new ChunkDownloader(webClient);
			_fileCombinerService = new FileCombinerService();
		} 

		#endregion Constructor
		
		#region IStreamingCombinePresenter Members

		/// <summary>
		/// Gets the chunk file list.
		/// </summary>
		/// <param name="streamingCombineUiModel">The conversion meta data.</param>
		/// <param name="progressIndicator">The progress indicator.</param>
		/// <returns></returns>
		public async Task<IStreamingCombineUiModel> GetChunkFileList(IStreamingCombineUiModel streamingCombineUiModel, Progress<int> progressIndicator)
		{
			streamingCombineUiModel.ParsedChunks = (await _chunkFileListService.GetChunkFileList(streamingCombineUiModel.ChunkListFileUrl));

			streamingCombineUiModel.NumberOfChunkFiles = streamingCombineUiModel.ParsedChunks.Count;

			return streamingCombineUiModel;
		}

		/// <summary>
		/// Downloads the chunk files.
		/// </summary>
		/// <param name="conversionMetaData">The conversion meta data.</param>
		/// <param name="progressIndicator">The progress indicator.</param>
		public void DownloadChunkFiles(IStreamingCombineUiModel streamingCombineUiModel, Progress<int> progressIndicator)
		{
			_chunkDownloader.DownloadFileChunks(streamingCombineUiModel.ParsedChunks, streamingCombineUiModel.TempDirectory);
		}

		/// <summary>
		/// Combines the chunk files.
		/// </summary>
		/// <param name="streamingCombineUiModel">The conversion meta data.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		public void CombineChunkFiles(IStreamingCombineUiModel streamingCombineUiModel)
		{
			IEnumerable<FileInfo> chunkFiles = _fileCombinerService.GetChunkFileInfos(streamingCombineUiModel.TempDirectory);

			_fileCombinerService.CombineChunkFiles(chunkFiles, streamingCombineUiModel.UnconvertedFilePath);

			if (streamingCombineUiModel.CanDeleteOldChunkFiles)
			{
				foreach (var chunkFile in chunkFiles)
				{
					chunkFile.Delete();
				}
			}
		}

		/// <summary>
		/// Converts the original '.ts' file into an mp4 file using ffmpeg.
		/// </summary>
		/// <param name="streamingCombineUiModel">The conversion meta data.</param>
		public void ConvertFile(IStreamingCombineUiModel streamingCombineUiModel)
		{
			FrapperWrapper frapperWrapper = new FrapperWrapper(new FFMPEG());

			IFfmpegCommand command = new FfmpegConversionCommandBuilder()
				.AddInputFilePath(streamingCombineUiModel.UnconvertedFilePath)
				.AddOutputFilePath(streamingCombineUiModel.ConvertedFilePath)
				.AddBitStreamFilter(BitStreamFilter.AacAdtstoasc)
				.GetCommand();

			frapperWrapper.ExecuteCommand(command);

			if (streamingCombineUiModel.CanDeleteUnconvertedFile)
			{
				DeleteFile(streamingCombineUiModel.UnconvertedFilePath);
			}
		}

		#endregion IStreamingCombinePresenter Members

		#region Helper Methods

		/// <summary>
		/// Deletes the file if it exists.
		/// </summary>
		/// <param name="filePath">The file path.</param>
		private static void DeleteFile(string filePath)
		{
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
		}

		#endregion Helper Methods
	}
}