using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle
{
    /// <summary>
    /// Класс, который создает google таблицу.
    /// </summary>
    /// <inheritdoc/>
    class CreatorSpreasheet : ICreatorSpreasheet
    {
        IWriterSheets writerSheets;
        IWorkFiles workFiles;
        /// <summary>
        /// Конструктор через который просходят иньекции объектов.
        /// </summary>
        /// <param name="writerSheets">Отвечает за запись данных в google лист.</param>
        /// <param name="workFiles">Отвечает за запись данных в txt файл, если не удалось соединиться с google Api и сработало исключение.</param>
        public CreatorSpreasheet(IWriterSheets writerSheets, IWorkFiles workFiles)
        {
            this.writerSheets = writerSheets;
            this.workFiles = workFiles;
        }
        public void CreateSpreasheet(IList<IServerObj> servers, SheetsService sheetService) // Метод создания таблицы.
        {
            string spreadsheetName = ConfigurationManager.AppSettings["NameSpreadSheet"];

            var myNewSheet = new Spreadsheet();
            myNewSheet.Properties = new SpreadsheetProperties();
            myNewSheet.Properties.Title = spreadsheetName;

            myNewSheet.Sheets = new List<Sheet>();
            for (int a = 0; a < servers.Count; a++)
            {
                var sheet = new Sheet();
                sheet.Properties = new SheetProperties();
                sheet.Properties.Title = servers[a].NameServer;
                myNewSheet.Sheets.Add(sheet);
            }

            try
            {
                Spreadsheet newSheet = sheetService.Spreadsheets.Create(myNewSheet).Execute();
                Console.WriteLine("--Таблица создана\nСсылка на таблицу: {0}", newSheet.SpreadsheetUrl);

                writerSheets.WriteSheet(newSheet.SpreadsheetId.ToString(), servers, sheetService);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: Не удается соединится с google api, таблица не создана.", e.Message);
                workFiles.WriteFileTxt(servers);
                Console.WriteLine("Данные записаны в файл: {0}, в корневой папке программы.\nНажмите любую кнопку для закрытия программы.", ConfigurationManager.AppSettings["PathFileTxt"]);
                Console.ReadKey();
                Environment.Exit(1);
            }  
        }
    }
}
