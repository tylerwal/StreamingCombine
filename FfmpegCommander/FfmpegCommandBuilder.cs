namespace FileCombiner.Ffmpeg
{
	public class FfmpegConversionCommandBuilder : IFfmpegCommandBuilder
	{
		private string _inputFilePath;

		private string _outputFilePath;

		private BitStreamFilter _bsf;

		public FfmpegConversionCommandBuilder AddInputFilePath(string path)
		{
			_inputFilePath = path;
			return this;
		}

		public FfmpegConversionCommandBuilder AddOutputFilePath(string path)
		{
			_outputFilePath = path;
			return this;
		}

		public FfmpegConversionCommandBuilder AddBitStreamFilter(BitStreamFilter bsf)
		{
			_bsf = bsf;
			return this;
		}

		public IFfmpegCommand GetCommand()
		{
			return new FfmpegConversionCommand(_inputFilePath, _outputFilePath, _bsf);
		}
	}
}