using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace TestBars.WorkSheetsGoogle
{
    class SearchSpreadsheets : ISearchSpreadsheets//Класс для работы с гугл диском
    {
        DriveService service;
        public DriveService driveService
        {
            set
            {
                if (service == null)
                {
                    service = value;
                }
            }
        }
        
        public string Search()// Метод поиска таблицы по названию
        {
            string spreadsheetId = null;
            FileList folderId = null;
            try
            {
                FilesResource.ListRequest request = service.Files.List();
                request.Q = $"mimeType = 'application/vnd.google-apps.spreadsheet' and name = '{ConfigurationManager.AppSettings["NameSpreadSheet"]}'";
                folderId = request.Execute();
            }
            catch(Exception e)
            {
                Console.WriteLine("Ошибка: {0}\nНажмите любую кнопку для закрытия программы",e.Message);
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
