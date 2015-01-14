namespace FileCombiner.Contracts
{
	public interface IMedia
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