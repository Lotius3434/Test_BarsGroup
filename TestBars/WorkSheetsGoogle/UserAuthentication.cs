using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading;

namespace TestBars.WorkSheetsGoogle
{
    class UserAuthentication : IUserAuthentication
    {
        UserCredential credential;
        string[] Scopes = { SheetsService.Scope.Spreadsheets, SheetsService.Scope.Drive }; // Доступные разрешения для работы с Google Api.
        
        public UserCredential Authentication()
        {
            
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["credentials"])))
                {
                    var credPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, "CredentialMonitorDb.json");
                    credential =
                        GoogleWebAuthorizationBroker.AuthorizeAsync(
                            GoogleClientSecrets.Load(stream).Secrets,
                            Scopes,
                            "user",
                            CancellationToken.None,
                            new FileDataStore(credPath, true)).Result;
                    Console.WriteLine(DateTime.Now.ToString() + ": Credential файл сохранен по ссылке: " + credPath);
                }
            
           
            

            return credential;
        }
    }
}
