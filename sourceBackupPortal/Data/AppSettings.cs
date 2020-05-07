using Microsoft.Extensions.Configuration;
using System;
using sourceBackup.Portal.Data.Interfaces;


namespace sourceBackup.Portal.Data
{
	/// <summary>
	/// contains methods for reading/writing values to config files
	/// </summary>
	public class AppSettings : IAppSettings
	{
		private readonly IConfiguration _configuration;
		public AppSettings()
		{
		}

		public AppSettings(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		private string DecryptAppSetting(string settingName)
		{
			var settingValue = _configuration.GetSection(settingName).Value;
			Byte[] b = Convert.FromBase64String(settingValue);
			string decryptedConnectionString = System.Text.ASCIIEncoding.ASCII.GetString(b); 
			return decryptedConnectionString;
		}

		public string GetAppSetting(string settingName, bool encrypted = false)
		{
			string returnValue = "";
			if(encrypted)
			{
				returnValue = DecryptAppSetting(settingName);
			}
			else
			{
                returnValue = _configuration.GetSection(settingName).Value.ToString();
			}
			return returnValue;
		}

	}
}
