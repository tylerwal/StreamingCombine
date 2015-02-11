
using FileCombiner.Ffmpeg;

using Frapper;

namespace FfmpegCommander
{
	public class FrapperWrapper : IFfmpegInterface
	{
		/// <summary>
		/// Gets or sets the frapper.
		/// </summary>
		/// <value>
		/// The frapper.
		/// </value>
		private FFMPEG Frapper
		{
			get;
			set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FrapperWrapper"/> class.
		/// </summary>
		/// <param name="frapper">The frapper.</param>
		public FrapperWrapper(FFMPEG frapper)
		{
			Frapper = frapper;
		}

		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <returns></returns>
		public string ExecuteCommand(IFfmpegCommand command)
		{
			return Frapper.RunCommand(command.GetCommand());
		}
	}
}