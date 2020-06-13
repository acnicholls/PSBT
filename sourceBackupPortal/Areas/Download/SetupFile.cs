using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sourceBackup.Portal.Areas.Download.Interfaces;
using System;
using System.IO;

namespace sourceBackup.Portal.Areas.Download
{
    /// <summary>
    /// this class allows a registered user to download the setup file for project : sourceBackup
    /// </summary>
    public class SetupFile : ISetupFile
    {
        private readonly ILogger<SetupFile> _logger;

        // setup file name
        private readonly string _setupFileFolder = AppDomain.CurrentDomain.BaseDirectory + @"\App_Data\SetupFile";
        private readonly string _setupFileName = "ProjectSourceBackupToolSetup.msi";

        public SetupFile(ILogger<SetupFile> logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// sends the setup file to the user
        /// </summary>
        /// <returns></returns>
        public FileStreamResult DownloadAsync()
        {
            try
            {
                FileStream stream = new FileStream(Path.Combine(_setupFileFolder, _setupFileName), FileMode.Open);
                    return new FileStreamResult(stream, new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("application/msi"))
                    {
                        FileDownloadName = _setupFileName
                    };
            }
            catch (Exception x)
            {
                _logger.LogError(x, "DownloadAsync");
                throw x;
            }
            
        }
    }
}
