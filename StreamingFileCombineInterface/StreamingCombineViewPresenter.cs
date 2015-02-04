using System.IO;

using FileCombiner;
using FileCombiner.Contracts;
using FileCombiner.Ffmpeg;

using Frapper;

using StreamingFileCombineInterface.Contracts;
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

		private FileInfo _unconvertedFile;

		#endregion Fields

		#region Constructor

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

		public async Task<IConversionMetaData> GetChunkFileList(IConversionMetaData conversionMetaData)
		{
			conversionMetaData.ParsedChunks = (await _listService.GetChunkFileList(conversionMetaData));

			conversionMetaData.NumberOfChunkFiles = conversionMetaData.ParsedChunks.Count;

			return conversionMetaData;
		}

		public void DownloadChunkFiles(IConversionMetaData conversionMetaData)
		{
			_chunkDownloader.Initialize(conversionMetaData);
			_chunkDownloader.DownloadFileChunks();
		}

		public void ConvertFile(string unconvertedFilePath, string convertedFilePath)
		{
			FrapperWrapper frapperWrapper = new FrapperWrapper(new FFMPEG());

			IFfmpegCommand command = new FfmpegConversionCommandBuilder()
				.AddInputFilePath(unconvertedFilePath)
				.AddOutputFilePath(convertedFilePath)
				.AddBitStreamFilter(BitStreamFilter.AacAdtstoasc)
				.GetCommand();

			frapperWrapper.ExecuteCommand(command);
		}

		#endregion
	}
}