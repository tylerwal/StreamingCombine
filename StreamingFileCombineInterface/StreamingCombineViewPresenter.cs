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

		private readonly IChunkFileListService _listService;
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

			_listService = new ChunkFileListService(webClient);
			_fileCombinerService = new FileCombinerService();
			_chunkDownloader = new ChunkDownloader(webClient);
		} 

		#endregion Constructor
		
		#region IStreamingCombinePresenter Members

		/// <summary>
		/// Gets the chunk file list.
		/// </summary>
		/// <param name="conversionMetaData">The conversion meta data.</param>
		/// <param name="progressIndicator">The progress indicator.</param>
		/// <returns></returns>
		public async Task<IConversionMetaData> GetChunkFileList(IConversionMetaData conversionMetaData, Progress<int> progressIndicator)
		{
			conversionMetaData.ParsedChunks = (await _listService.GetChunkFileList(conversionMetaData.ChunkListFileUrl));

			conversionMetaData.NumberOfChunkFiles = conversionMetaData.ParsedChunks.Count;

			return conversionMetaData;
		}

		/// <summary>
		/// Downloads the chunk files.
		/// </summary>
		/// <param name="conversionMetaData">The conversion meta data.</param>
		public void DownloadChunkFiles(IConversionMetaData conversionMetaData)
		{
			_chunkDownloader.Initialize(conversionMetaData);
			_chunkDownloader.DownloadFileChunks();
		}

		/// <summary>
		/// Combines the chunk files.
		/// </summary>
		/// <param name="conversionMetaData">The conversion meta data.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		public void CombineChunkFiles(IConversionMetaData conversionMetaData)
		{
			IEnumerable<FileInfo> chunkFiles = _fileCombinerService.GetChunkFileInfos(conversionMetaData.TempDirectory);

			_fileCombinerService.CombineChunkFiles(chunkFiles, conversionMetaData.UnconvertedFilePath);

			if (conversionMetaData.CanDeleteOldChunkFiles)
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
		/// <param name="conversionMetaData">The conversion meta data.</param>
		public void ConvertFile(IConversionMetaData conversionMetaData)
		{
			FrapperWrapper frapperWrapper = new FrapperWrapper(new FFMPEG());

			IFfmpegCommand command = new FfmpegConversionCommandBuilder()
				.AddInputFilePath(conversionMetaData.UnconvertedFilePath)
				.AddOutputFilePath(conversionMetaData.ConvertedFilePath)
				.AddBitStreamFilter(BitStreamFilter.AacAdtstoasc)
				.GetCommand();

			frapperWrapper.ExecuteCommand(command);

			if (conversionMetaData.CanDeleteUnconvertedFile)
			{
				DeleteFile(conversionMetaData.UnconvertedFilePath);
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