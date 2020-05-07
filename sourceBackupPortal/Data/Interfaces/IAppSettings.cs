namespace sourceBackup.Portal.Data.Interfaces
{
    public interface IAppSettings
    {
        string GetAppSetting(string settingName, bool encrypted = false);

    }
}
