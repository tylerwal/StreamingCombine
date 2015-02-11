namespace StreamingFileCombineInterface.Contracts
{
	public interface IStreamingCombineView
	{
		/// <summary>
		/// Adds to progress status.
		/// </summary>
		/// <param name="newestInput">The newest input.</param>
		void AddToProgressStatus(string newestInput);
	}
}