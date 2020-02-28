﻿using Google.Apis.Drive.v3;
using System;
using System.Collections.Generic;

namespace TestBars.WorkSheetsGoogle
{
    class SearchSpreadsheets //Класс для работы с гугл диском
    {
        public List<string> Search(DriveService service)// Метод поиска таблицы по названию
        {
            List<string> listId = new List<string>();

            
            FilesResource.ListRequest request = service.Files.List();
            request.Q = $"mimeType = 'application/vnd.google-apps.spreadsheet' and name = '{Config_Scope_Appname.NameSpreadSheet}'";
            var folderId = request.Execute();
            
            if (folderId.Files.Count > 0)
            {
                for (int a = 0; a < folderId.Files.Count; a++)
                {
                    listId.Add(folderId.Files[a].Id);
                    Console.WriteLine("Найдена таблица: {0}", Config_Scope_Appname.NameSpreadSheet);
                }
            }

            return listId;

        }
    }
}
