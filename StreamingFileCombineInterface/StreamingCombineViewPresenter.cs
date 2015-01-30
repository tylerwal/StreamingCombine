using System.IO;

using FileCombiner;
using FileCombiner.Contracts;
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

		private FileInfo _unconvertedFile;

		#endregion Fields

		#region Constructor

		public StreamingCombineViewPresenter(IStreamingCombineView view)
		{
			_streamingCombineView = view;

			WebClient webClient = new WebClient();

			_listService = new ChunkFileListService(webClient);
			_fileCombinerService = new FileCombinerService(webClient);
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
			_fileCombinerService.Initialize(conversionMetaData);
			_fileCombinerService.DownloadFileChunks();
		}

		public void DoItAll(IConversionMetaData conversionMetaData)
		{
			_listService.DoItAll(conversionMetaData);
		}

		#endregion
	}
}