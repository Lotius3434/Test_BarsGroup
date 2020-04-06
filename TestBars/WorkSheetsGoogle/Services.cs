using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System.Configuration;

namespace TestBars.WorkSheetsGoogle
{
    /// <summary>
    ///Класс, который отвечает за создание сервисов, после аутентификации пользователя.
    /// </summary>
    /// <inheritdoc/>
    public class Services : IServices
    {
        
        UserCredential _credential;
        /// <summary>
        /// Конструктор через который просходят иньекция объекта.
        /// </summary>
        /// <param name="userAuthentication">Отвечает за аутентификацию пользователя.</param>
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
