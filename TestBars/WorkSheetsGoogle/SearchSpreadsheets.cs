using Google.Apis.Drive.v3;
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

            
            FilesResource.ListRequest request = service.Files.List();
            request.Q = $"mimeType = 'application/vnd.google-apps.spreadsheet' and name = '{ConfigurationManager.AppSettings["NameSpreadSheet"]}'";
            var folderId = request.Execute();
            
            if (folderId.Files.Count > 0)
            {
                
                    spreadsheetId = folderId.Files[0].Id;
                    Console.WriteLine("Найдена таблица: {0}", ConfigurationManager.AppSettings["NameSpreadSheet"]);
                
            }

            return spreadsheetId;

        }
    }
}
