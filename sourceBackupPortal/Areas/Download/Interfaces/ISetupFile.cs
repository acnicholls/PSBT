using Microsoft.AspNetCore.Mvc;

namespace sourceBackup.Portal.Areas.Download.Interfaces
{
    public interface ISetupFile
    {
        FileStreamResult DownloadAsync();
    }
}
