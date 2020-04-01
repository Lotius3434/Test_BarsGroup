using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System.Configuration;

namespace TestBars.WorkSheetsGoogle
{
    class Services : IGetSheetsService , IGetDriveService
    {
        UserCredential credential;
        public Services(UserCredential credential)
        {
            if (credential != null)
            {
                this.credential = credential;
            }

        }
        public SheetsService GetSheetsService()
        {
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ConfigurationManager.AppSettings["ApplicationName"],
            });
            return service;
        }
        public DriveService GetDriveService()
        {
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ConfigurationManager.AppSettings["ApplicationName"],
            });
            return service;
        }
    }
}
