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
		}

		#region IStreamingCombinePresenter Members

		public void GetChunkFiles(ConversionMetaData conversionMetaData)
		{
			throw new System.NotImplementedException();
		}

		#endregion
	}
}