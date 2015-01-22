
using Frapper;

namespace FileCombiner.Ffmpeg
{
	public class FrapperWrapper : IFfmpegInterface
	{
		private FFMPEG Frapper
		{
			get;
			set;
		}

		public FrapperWrapper(FFMPEG frapper)
		{
			Frapper = frapper;
		}

		public string ExecuteCommand(IFfmpegCommand command)
		{
			return Frapper.RunCommand(command.GetCommand());
		}
	}
}