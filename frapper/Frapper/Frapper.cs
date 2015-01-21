using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Frapper
{
    public class FFMPEG
    {
        #region Properties
        private string _ffExe;
        public string ffExe
        {
            get
            {
                return _ffExe;
            }
            set
            {
                _ffExe = value;
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
            _ffExe = ffmpegExePath;
            Initialize();
        }
        #endregion

        #region Initialization
        private void Initialize()
        {
            //first make sure we have a value for the ffexe file setting
            if (string.IsNullOrEmpty(_ffExe))
            {
                object o = ConfigurationManager.AppSettings["ffmpeg:ExeLocation"];

                if (o == null)
                {
                    throw new Exception("Could not find the location of the ffmpeg exe file.  The path for ffmpeg.exe " +
                    "can be passed in via a constructor of the ffmpeg class (this class) or by setting in the app.config or web.config file.  " +
                    "in the appsettings section, the correct property name is: ffmpeg:ExeLocation");
                }
                else
                {
                    if (string.IsNullOrEmpty(o.ToString()))
                        throw new Exception("No value was found in the app setting for ffmpeg:ExeLocation");

                    _ffExe = o.ToString();
                }
            }

            if (!File.Exists(_ffExe))
                throw new Exception("Could not find a copy of ffmpeg.exe");
        }
        #endregion

        #region Run the process
        public string RunCommand(string Parameters)
        {
            //create a process info
            ProcessStartInfo oInfo = new ProcessStartInfo(this._ffExe, Parameters);
            oInfo.UseShellExecute = false;
	       oInfo.CreateNoWindow = true;
            oInfo.RedirectStandardOutput = true;
            oInfo.RedirectStandardError = true;

            //Create the output and streamreader to get the output
            string output = null; StreamReader srOutput = null;

            //try the process
            try
            {
                //run the process
                Process proc = System.Diagnostics.Process.Start(oInfo);

                //proc.WaitForExit();

                //get the output
                srOutput = proc.StandardError;

                //now put it in a string
                output = srOutput.ReadToEnd();

                proc.Close();
            }
            catch (Exception)
            {
                output = string.Empty;
            }
            finally
            {
                //now, if we succeded, close out the streamreader
                if (srOutput != null)
                {
                    srOutput.Close();
                    srOutput.Dispose();
                }
            }
            return output;
        }
        #endregion
    }

}