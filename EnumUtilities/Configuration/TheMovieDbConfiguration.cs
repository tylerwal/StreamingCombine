using System.Configuration;

namespace MediaHandleUtilities.Configuration
{
	public class TheMovieDbConfiguration : ConfigurationSection
	{
		[ConfigurationProperty("Url")]
		public string Url
		{
			get { return (string)this["Url"]; }
			//set { this["Username"] = value; }
		}

		[ConfigurationProperty("ApiKey")]
		public string ApiKey
		{
			get { return (string)this["ApiKey"]; }
			//set { this["Password"] = value; }
		}
	}
}
