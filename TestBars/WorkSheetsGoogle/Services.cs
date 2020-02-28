using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;

namespace TestBars.WorkSheetsGoogle
{
    class Services
    {
        public SheetsService GetSheetsService()
        {
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = Config_Scope_Appname.credential,
                ApplicationName = Config_Scope_Appname.ApplicationName,
            });
            return service;
        }
        public DriveService GetDriveService()
        {
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = Config_Scope_Appname.credential,
                ApplicationName = Config_Scope_Appname.ApplicationName,
            });
            return service;
        }
    }
}
