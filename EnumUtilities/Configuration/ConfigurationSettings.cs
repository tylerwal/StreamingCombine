using System.Configuration;

namespace MediaHandleUtilities.Configuration
{
	public static class ConfigurationSettings
	{
		#region Fields

		private static OpenSubtitlesConfiguration _openSubtitlesConfiguration;

		private static TheMovieDbConfiguration _theMovieDbConfiguration;

		#endregion Fields

		#region Properties

		public static OpenSubtitlesConfiguration OpenSubtitles
		{
			get
			{
				if (_openSubtitlesConfiguration == null)
				{
					_openSubtitlesConfiguration = ConfigurationManager.GetSection("OpenSubtitles") as OpenSubtitlesConfiguration;
				}

				return _openSubtitlesConfiguration;
			}
			private set
			{
				_openSubtitlesConfiguration = value;
			}
		}

		public static TheMovieDbConfiguration TheMovieDb
		{
			get
			{
				if (_theMovieDbConfiguration == null)
				{
					_theMovieDbConfiguration = ConfigurationManager.GetSection("TheMovieDb") as TheMovieDbConfiguration;
				}

				return _theMovieDbConfiguration;
			}
			private set
			{
				_theMovieDbConfiguration = value;
			}
		}

		#endregion Properties
	}
}