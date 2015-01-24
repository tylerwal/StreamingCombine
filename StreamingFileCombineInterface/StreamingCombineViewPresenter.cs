using StreamingFileCombineInterface.Contracts;

namespace StreamingFileCombineInterface
{
	public class StreamingCombineViewPresenter : IStreamingCombinePresenter
	{
		private IStreamingCombineView _streamingCombineView;

		public StreamingCombineViewPresenter(IStreamingCombineView view)
		{
			_streamingCombineView = view;
		}
	}
}