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

		private IParser _fileChunks;

		public StreamingCombineViewPresenter(IStreamingCombineView view)
		{
			_streamingCombineView = view;

			_combinerService = new ChunkFileCombinerService();
		}

		#region IStreamingCombinePresenter Members

		public void GetChunkFiles(ref ConversionMetaData conversionMetaData)
		{
			_fileChunks = _combinerService.GetFileChunks(conversionMetaData);

			conversionMetaData.NumberOfChunkFiles = _fileChunks.StreamingFileUris.Count;
		}

		public void DoItAll(ConversionMetaData conversionMetaData)
		{
			_combinerService.CreateCombinedFile(conversionMetaData);
		}

		#endregion
	}
}