using System.Net;

using FileCombiner;
using FileCombiner.Contracts;
using StreamingFileCombineInterface.Contracts;
using System.Threading.Tasks;

namespace StreamingFileCombineInterface
{
	public class StreamingCombineViewPresenter : IStreamingCombinePresenter
	{
		private IStreamingCombineView _streamingCombineView;
		private IChunkFileCombinerService _combinerService;
		
		public StreamingCombineViewPresenter(IStreamingCombineView view)
		{
			_streamingCombineView = view;

			_combinerService = new ChunkFileCombinerService(new WebClient());
		}

		#region IStreamingCombinePresenter Members

		public async Task<ConversionMetaData> GetChunkFileList(ConversionMetaData conversionMetaData)
		{
			conversionMetaData.ParsedChunks = (await _combinerService.GetChunkFileList(conversionMetaData));

			conversionMetaData.NumberOfChunkFiles = conversionMetaData.ParsedChunks.Count;

			return conversionMetaData;
		}

		public void DoItAll(ConversionMetaData conversionMetaData)
		{
			_combinerService.CreateCombinedFile(conversionMetaData);
		}

		#endregion
	}
}