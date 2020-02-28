using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading;

namespace TestBars.WorkSheetsGoogle
{
    class UserAuthentication
    {
        public UserCredential Authentication()
        {

            UserCredential credential;

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["credentials"])))
            {
                var credPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, "CredentialMonitorDb.json");
                credential =
                    GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Config_Scope_Appname.Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                Console.WriteLine(DateTime.Now.ToString() + ": Credential файл сохранен по ссылке: " + credPath);
            }

            return credential;
        }
    }
}
