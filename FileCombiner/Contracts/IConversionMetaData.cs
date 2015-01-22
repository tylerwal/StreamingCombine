namespace FileCombiner.Contracts
{
	public interface IConversionMetaData
	{
		string OutputDirectory
		{
			get;
			set;
		}

		string CreateOutputFilePath();

		string GetFilePathCorrectedName();
	}
}