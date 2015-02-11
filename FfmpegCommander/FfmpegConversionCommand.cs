using FfmpegCommanderUtilities;
using System.Text;

namespace FileCombiner.Ffmpeg
{
	internal class FfmpegConversionCommand : IFfmpegCommand
	{
		/// <summary>
		/// Gets or sets the input file path.
		/// </summary>
		/// <value>
		/// The input file path.
		/// </value>
		private string InputFilePath
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the output file path.
		/// </summary>
		/// <value>
		/// The output file path.
		/// </value>
		private string OutputFilePath
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the BSF.
		/// </summary>
		/// <value>
		/// The BSF.
		/// </value>
		private BitStreamFilter Bsf
		{
			get;
			set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FfmpegConversionCommand"/> class.
		/// </summary>
		/// <param name="inputFilePath">The input file path.</param>
		/// <param name="outputFilePath">The output file path.</param>
		/// <param name="bitStreamFilter">The bit stream filter.</param>
		internal FfmpegConversionCommand(string inputFilePath, string outputFilePath, BitStreamFilter bitStreamFilter)
		{
			InputFilePath = inputFilePath;
			OutputFilePath = outputFilePath;
			Bsf = bitStreamFilter;
		}

		/// <summary>
		/// Gets the command.
		/// </summary>
		/// <returns></returns>
		public string GetCommand()
		{
			string command = new StringBuilder()
				.AddInputArgument()
				.addFilePath(InputFilePath)
				.addVideoCopy()
				.addAudioCopy()
				.addBitStreamFilter(BitStreamFilter.AacAdtstoasc)
				.addFilePath(OutputFilePath)
				.ToString();

			return command;
		}
	}
}