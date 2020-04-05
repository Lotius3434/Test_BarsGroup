using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle
{
    public class SearchSpreadsheets : ISearchSpreadsheets//Класс для работы с гугл диском
    {
        IWorkFiles workFiles;
        
        
        public SearchSpreadsheets(IWorkFiles workFiles)
        {
            this.workFiles = workFiles;
        }
        
        public string Search(IList<IServerObj> servers, DriveService driveService)// Метод поиска таблицы по названию
        {
            
            string spreadsheetId = null;
            FileList folderId = null;
            Console.WriteLine("Сканирование google disk");
            try
            {
                FilesResource.ListRequest request = driveService.Files.List();
                request.Q = $"mimeType = 'application/vnd.google-apps.spreadsheet' and name = '{ConfigurationManager.AppSettings["NameSpreadSheet"]}'";
                folderId = request.Execute();
            }
            catch(Exception e)
            {
                Console.WriteLine("Ошибка: Не удается соединится с google api", e.Message);
                workFiles.WriteFileTxt(servers);
                Console.WriteLine("Данные записаны в файл: {0}, в корневой папке программы\nНажмите любую кнопку для закрытия программы", ConfigurationManager.AppSettings["PathFileTxt"]);
                Console.ReadKey();
                Environment.Exit(1);
            }
            
            
            if ( folderId != null && folderId.Files.Count > 0 )
            {
                
                    spreadsheetId = folderId.Files[0].Id;
                    Console.WriteLine("Найдена таблица: {0}", ConfigurationManager.AppSettings["NameSpreadSheet"]);
                
            }

            return spreadsheetId;

        }
    }
}
