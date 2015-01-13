using System.Text;

using FileCombiner.Contracts;

namespace FileCombiner
{
	public class Media : IMedia
	{
		#region Fields

		private const string _outputCombinedFileExtension = ".ts"; 

		#endregion Fields

		public string ChunkListFileUrl
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string OutputDirectory
		{
			get;
			set;
		}

		#region PublicMethods

		public string GetFilePathCorrectedName()
		{
			return Name.Replace(" ", string.Empty);
		}

		public string CreateOutputFileName()
		{
			StringBuilder combinedFilePathBuilder = new StringBuilder();
			combinedFilePathBuilder.Append(OutputDirectory);
			combinedFilePathBuilder.Append(GetFilePathCorrectedName());
			combinedFilePathBuilder.Append(_outputCombinedFileExtension);

			return combinedFilePathBuilder.ToString();
		}

		#endregion PublicMethods
	}
}