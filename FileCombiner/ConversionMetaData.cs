using System.IO;
using System.Text;

using FileCombiner.Contracts;

namespace FileCombiner
{
	public class ConversionMetaData : IConversionMetaData
	{
		#region Fields

		private const string _outputCombinedFileExtension = ".ts"; 

		#endregion Fields

		public string ChunkListFileUrl
		{
			get;
			set;
		}

		public int NumberOfChunkFiles
		{
			get;
			set;
		}

		public string MediaName
		{
			get;
			set;
		}

		public string OutputDirectory
		{
			get;
			set;
		}

		public string TempDirectory
		{
			get;
			set;
		}

		public string UnConvertedFilePath
		{
			get;
			set;
		}

		public string ConvertedFilePath
		{
			get;
			set;
		}

		#region PublicMethods

		public string GetFilePathCorrectedName()
		{
			return MediaName.Replace(" ", string.Empty);
		}

		public string CreateOutputFilePath()
		{
			StringBuilder combinedFilePathBuilder = new StringBuilder();
			combinedFilePathBuilder.Append(GetFilePathCorrectedName());
			combinedFilePathBuilder.Append(_outputCombinedFileExtension);

			return Path.Combine(OutputDirectory, combinedFilePathBuilder.ToString());
		}

		#endregion PublicMethods
	}
}