using System.Text;

using FileCombiner.Ffmpeg;

namespace FfmpegCommanderUtilities
{
	public static class StringBuilderUtilities
	{
		public static StringBuilder AddInputArgument(this StringBuilder builder)
		{
			return builder.Append("-" + Constants.INPUT_ARGUMENT);
		}

		public static StringBuilder addFilePath(this StringBuilder builder, string path)
		{
			return builder.Append(" " + path);
		}
		
		public static StringBuilder addVideoCopy(this StringBuilder builder)
		{
			return builder.Append(CreateArgument(Constants.VIDEO_CODEC_ARGUMENT, Constants.COPY_ARGUMENT_INPUT));
		}

		public static StringBuilder addAudioCopy(this StringBuilder builder)
		{
			return builder.Append(CreateArgument(Constants.AUDIO_CODEC_ARGUMENT, Constants.COPY_ARGUMENT_INPUT));
		}

		public static StringBuilder addBitStreamFilter(this StringBuilder builder, BitStreamFilter bsf)
		{
			return builder.Append(CreateArgument(Constants.BIT_STREAM_FILTER_ARGUMENT, Utilities.EnumUtilities.GetStringValue(bsf)));
		}

		#region Private Methods
		
		private static string CreateArgument(string argumentText, string argumentInput)
		{
			return " -" + argumentText + " " + argumentInput;
		} 

		#endregion Private Methods
	}
}