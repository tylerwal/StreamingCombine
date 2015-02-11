using FileCombiner.Contracts;

namespace FileCombiner.Domain
{
	public class ProgressData : IProgressData
	{
		#region IProgressData Members

		/// <summary>
		/// Gets or sets the percent done.
		/// </summary>
		/// <value>
		/// The percent done.
		/// </value>
		public int PercentDone
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
		public string Status
		{
			get;
			set;
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ProgressData"/> class.
		/// </summary>
		public ProgressData()
		{
			PercentDone = 0;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ProgressData"/> class.
		/// </summary>
		/// <param name="percentDone">The percent done.</param>
		public ProgressData(int percentDone)
		{
			PercentDone = percentDone;
		}

		#endregion Constructors
	}
}