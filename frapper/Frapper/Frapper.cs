using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace Frapper
{
	public class FFMPEG
	{
		#region Properties
		private string _ffmpegExecutableLocation;
		public string FfmpegExecutableLocation
		{
			get
			{
				return _ffmpegExecutableLocation;
			}
			set
			{
				_ffmpegExecutableLocation = value;
			}
		}
		#endregion

		#region Constructors
		public FFMPEG()
		{
			Initialize();
		}
		public FFMPEG(string ffmpegExePath)
		{
			_ffmpegExecutableLocation = ffmpegExePath;
			Initialize();
		}
		#endregion

		#region Initialization
		private void Initialize()
		{
			//first make sure we have a value for the ffexe file setting
			if (string.IsNullOrEmpty(_ffmpegExecutableLocation))
			{
				object ffmpegExecutableLocation = ConfigurationManager.AppSettings["ffmpeg:ExeLocation"];

				if (ffmpegExecutableLocation == null)
				{
					throw new Exception(
						"Could not find the location of the ffmpeg exe file.  The path for ffmpeg.exe " +
						"can be passed in via a constructor of the ffmpeg class (this class) or by setting in the app.config or web.config file.  " +
						"in the appsettings section, the correct property name is: ffmpeg:ExeLocation"
					);
				}
				else
				{
					if (string.IsNullOrEmpty(ffmpegExecutableLocation.ToString()))
					{
						throw new Exception("No value was found in the app setting for ffmpeg:ExeLocation");
					}

					_ffmpegExecutableLocation = ffmpegExecutableLocation.ToString();
				}
			}

			if (!File.Exists(_ffmpegExecutableLocation))
			{
				throw new Exception("Could not find a copy of ffmpeg.exe");
			}
		}
		#endregion

		#region Run the process
		public string RunCommand(string Parameters)
		{
			//create a process info
			ProcessStartInfo processStartInfo = new ProcessStartInfo(_ffmpegExecutableLocation, Parameters)
			{
				UseShellExecute = false,
				CreateNoWindow = false,
				RedirectStandardOutput = false,
				RedirectStandardError = false,
				WindowStyle = ProcessWindowStyle.Normal
			};

			//Create the output and streamreader to get the output
			string output = null;
			StreamReader processStandardErrorStreamReader = null;

			//try the process
			try
			{
				Process process = new Process
				{
					StartInfo = processStartInfo
				};

				process.Start();

				process.WaitForExit();

				//get the output
				processStandardErrorStreamReader = process.StandardError;

				//now put it in a string
				output = processStandardErrorStreamReader.ReadToEnd();

				process.Close();
			}
			catch (Exception)
			{
				output = string.Empty;
			}
			finally
			{
				//now, if we succeded, close out the streamreader
				if (processStandardErrorStreamReader != null)
				{
					processStandardErrorStreamReader.Close();
					processStandardErrorStreamReader.Dispose();
				}
			}
			return output;
		}
		#endregion
	}

}