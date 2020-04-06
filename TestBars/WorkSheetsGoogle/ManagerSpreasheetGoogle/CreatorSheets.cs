using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle
{
    /// <summary>
    /// Класс, который создает google лист, в существующей google таблице.
    /// </summary>
    /// <inheritdoc/>
    class CreatorSheets : ICreatorSheets
    {
        IWriterSheets writerSheets;
        IWorkFiles workFiles;
        /// <summary>
        /// Конструктор через который просходят иньекции объектов.
        /// </summary>
        /// <param name="writerSheets">Отвечает за запись в google лист, существующей google таблицы.</param>
        /// <param name="workFiles">Отвечает за запись данных в txt файл, если не удалось соединиться с google Api и сработало исключение.</param>
        public CreatorSheets(IWriterSheets writerSheets, IWorkFiles workFiles)
        {
            this.writerSheets = writerSheets;
            this.workFiles = workFiles;
        }
        public void CreateSheets(string SpreadsheetId, List<string> ListServer, IList<IServerObj> servers, SheetsService sheetService)
        {
            Console.WriteLine("Количество не найденых листов: {0}\nНачинается добавление недостающих листов...", ListServer.Count);

            foreach (var sheetName in ListServer)
            {
                var addSheetRequest = new AddSheetRequest();
                addSheetRequest.Properties = new SheetProperties();
                addSheetRequest.Properties.Title = sheetName;
                BatchUpdateSpreadsheetRequest batchUpdateSpreadsheetRequest = new BatchUpdateSpreadsheetRequest();
                batchUpdateSpreadsheetRequest.Requests = new List<Request>();
                batchUpdateSpreadsheetRequest.Requests.Add(new Request { AddSheet = addSheetRequest });

                var batchUpdateRequest = sheetService.Spreadsheets.BatchUpdate(batchUpdateSpreadsheetRequest, SpreadsheetId);
                
                try
                {
                    batchUpdateRequest.Execute();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка: Не удается соединится с google api, лист в таблице не создан.", e.Message);
                    workFiles.WriteFileTxt(servers);
                    Console.WriteLine("Данные записаны в файл: {0}, в корневой папке программы.\nНажмите любую кнопку для закрытия программы.", ConfigurationManager.AppSettings["PathFileTxt"]);
                    Console.ReadKey();
                    Environment.Exit(1);
                }
            }

            IList<IServerObj> newServers = new List<IServerObj>();

            for (int a = 0; a < ListServer.Count; a++)
            {
                foreach (var _servers in servers)
                {
                    if (ListServer[a].ToString() == _servers.NameServer)
                    {
                        newServers.Add(_servers);
                    }
                }
            }


            writerSheets.WriteSheet(SpreadsheetId, newServers, sheetService);
        }
    }
}
