using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;

namespace TestBars.WorkSheetsGoogle
{
    static class Config_Scope_Appname //Статический класс для хранение настроек и разрешений.
    {
        public static string[] Scopes = { SheetsService.Scope.Spreadsheets, SheetsService.Scope.Drive }; // Доступные разрешения для работы с Google Api.
        public static string ApplicationName = "Google Sheets Test";
        public static string NameSpreadSheet = "Server monitoring Test Bars"; //Название таблицы.
        public static UserCredential credential;

    }
}
