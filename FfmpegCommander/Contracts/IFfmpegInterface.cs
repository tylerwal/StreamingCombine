namespace FileCombiner.Ffmpeg
{
	public interface IFfmpegInterface
	{
		string ExecuteCommand(IFfmpegCommand command);
	}
}