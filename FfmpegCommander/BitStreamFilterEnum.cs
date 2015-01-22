using MediaHandleUtilities;

namespace FileCombiner.Ffmpeg
{
	public enum BitStreamFilter
	{
		[StringValue("text2movsub")]
		Text2Movsub,

		[StringValue("remove_extra")]
		RemoveExtra,

		[StringValue("noise")]
		Noise,

		[StringValue("mov2textsub")]
		Mov2Textsub,

		[StringValue("mp3decomp")]
		Mp3Decomp,

		[StringValue("mjpegadump")]
		Mjpegadump,

		[StringValue("mjpeg2jpeg")]
		Mjpeg2Jpeg,

		[StringValue("imxdump")]
		Imxdump,

		[StringValue("h264_mp4toannexb")]
		H264Mp4Toannexb,

		[StringValue("dump_extra")]
		DumpExtra,

		[StringValue("chomp")]
		Chomp,

		[StringValue("aac_adtstoasc")]
		AacAdtstoasc,
	}
}