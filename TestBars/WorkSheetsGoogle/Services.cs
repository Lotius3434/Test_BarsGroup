using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System.Configuration;

namespace TestBars.WorkSheetsGoogle
{
    public class Services : IServices
    {
        UserCredential _credential;
        public Services(IUserAuthentication userAuthentication)
        {
            this._credential = userAuthentication.Authentication();
        }
        public SheetsService GetSheetsService()
        {

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = _credential,
                ApplicationName = ConfigurationManager.AppSettings["ApplicationName"],
            });
            return service;
        }
        public DriveService GetDriveService()
        {
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = _credential,
                ApplicationName = ConfigurationManager.AppSettings["ApplicationName"],
            });
            return service;
        }
    }
}
