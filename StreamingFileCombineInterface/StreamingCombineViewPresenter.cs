using System.IO;
using System.Windows.Forms;

using FileCombiner;
using FileCombiner.Contracts;

using StreamingFileCombineInterface.Contracts;

namespace StreamingFileCombineInterface
{
	public class StreamingCombineViewPresenter : IStreamingCombinePresenter
	{
		private IStreamingCombineView _streamingCombineView;

		private IChunkFileCombinerService _combinerService;

		public StreamingCombineViewPresenter(IStreamingCombineView view)
		{
			_streamingCombineView = view;

			_combinerService = new ChunkFileCombinerService();
		}

		#region IStreamingCombinePresenter Members

		public void GetChunkFiles(ConversionMetaData conversionMetaData)
		{
			IParser fileChunks = _combinerService.GetFileChunks(conversionMetaData);
		}

		public void DoItAll(ConversionMetaData conversionMetaData)
		{
			_combinerService.CreateCombinedFile(conversionMetaData);
		}

		#endregion
	}
}