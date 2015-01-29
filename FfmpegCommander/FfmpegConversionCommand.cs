using FfmpegCommanderUtilities;
using System.Text;

namespace FileCombiner.Ffmpeg
{
	internal class FfmpegConversionCommand : IFfmpegCommand
	{
		private string InputFilePath
		{
			get;
			set;
		}

		private string OutputFilePath
		{
			get;
			set;
		}

		private BitStreamFilter Bsf
		{
			get;
			set;
		}

		internal FfmpegConversionCommand(string inputFilePath, string outputFilePath, BitStreamFilter bitStreamFilter)
		{
			InputFilePath = inputFilePath;
			OutputFilePath = outputFilePath;
			Bsf = bitStreamFilter;
		}

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