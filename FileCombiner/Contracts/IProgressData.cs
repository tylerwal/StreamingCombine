namespace FileCombiner.Contracts
{
	public interface IProgressData
	{
		/// <summary>
		/// Gets or sets the percent done.
		/// </summary>
		/// <value>
		/// The percent done.
		/// </value>
		int PercentDone
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the text.
		/// </summary>
		/// <value>
		/// The text.
		/// </value>
		string Status
		{
			get;
			set;
		}
	}
}