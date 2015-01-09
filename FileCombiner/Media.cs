using System.Text;

namespace FileCombiner
{
	public class Media
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

		public string GetCleansedName()
		{
			return Name.Replace(" ", string.Empty);
		}

		public string CreateOutputFileName()
		{
			StringBuilder combinedFilePathBuilder = new StringBuilder();
			combinedFilePathBuilder.Append(OutputDirectory);
			combinedFilePathBuilder.Append(GetCleansedName());
			combinedFilePathBuilder.Append(_outputCombinedFileExtension);

			return combinedFilePathBuilder.ToString();
		}

		#endregion PublicMethods
	}
}