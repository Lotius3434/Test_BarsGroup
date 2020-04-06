using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle
{
    /// <summary>
    /// Класс, который ищет таблицы в google disk, по названию.
    /// </summary>
    /// <inheritdoc/>
    public class SearchSpreadsheets : ISearchSpreadsheets
    {
        IWorkFiles workFiles;
        /// <summary>
        /// Конструктор через который просходят иньекция объекта.
        /// </summary>
        /// <param name="workFiles">Отвечает за запись данных в txt файл, если не удалось соединиться с google Api и сработало исключение.</param>
        public SearchSpreadsheets(IWorkFiles workFiles)
        {
            this.workFiles = workFiles;
        }        
        public string Search(IList<IServerObj> servers, DriveService driveService)
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
                Console.WriteLine("Ошибка: Не удается соединится с google api, не удалось отсканировать google disk.", e.Message);
                workFiles.WriteFileTxt(servers);
                Console.WriteLine("Данные записаны в файл: {0}, в корневой папке программы.\nНажмите любую кнопку для закрытия программы.", ConfigurationManager.AppSettings["PathFileTxt"]);
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
