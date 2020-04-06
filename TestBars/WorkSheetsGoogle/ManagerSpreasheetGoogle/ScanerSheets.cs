using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle
{
    /// <summary>
    /// Класс, который сканирует таблицу, на наличие листов для каждого сервера.
    /// </summary>
    /// <inheritdoc/>
    class ScanerSheets : IScanerSheets
    {
        ICreatorSheets creatorSheets;
        IWriterSheets writerSheets;
        IWorkFiles workFiles;
        /// <summary>
        /// Конструктор через который просходят иньекции объектов.
        /// </summary>
        /// <param name="creatorSheets">Отвечает за создание google листа, в существующей google таблице.</param>
        /// <param name="writerSheets">Отвечает за запись в google лист, существующей google таблицы.</param>
        /// <param name="workFiles">Отвечает за запись данных в txt файл, если не удалось соединиться с google Api и сработало исключение.</param>
        public ScanerSheets(ICreatorSheets creatorSheets, IWriterSheets writerSheets,IWorkFiles workFiles)
        {
            this.creatorSheets = creatorSheets;
            this.writerSheets = writerSheets;
            this.workFiles = workFiles;
        }
        public void ScanSheets(string IdSreadssheet, IList<IServerObj> servers, SheetsService sheetService)
        {
            Console.WriteLine("Сканирование листов в таблице");

            List<string> sheets = new List<string>();
            List<string> result = new List<string>();

            try
            {
                Spreadsheet gsSpreadsheet;
                gsSpreadsheet = sheetService.Spreadsheets.Get(IdSreadssheet).Execute();

                foreach (Sheet gsSheet in gsSpreadsheet.Sheets)
                {
                    sheets.Add(gsSheet.Properties.Title);
                }  
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: Не удается соединится с google api, не удалось отсканировать лист в таблице.", e.Message);
                workFiles.WriteFileTxt(servers);
                Console.WriteLine("Данные записаны в файл: {0}, в корневой папке программы.\nНажмите любую кнопку для закрытия программы.", ConfigurationManager.AppSettings["PathFileTxt"]);
                Console.ReadKey();
                Environment.Exit(1);
            }
            foreach (var nameServ in servers)
            {
                string Servsname = sheets.Find((x) => x == nameServ.NameServer);
                if (Servsname == null)
                {
                    result.Add(nameServ.NameServer);
                }
            }

            if (result.Count > 0) // Если соответствующих листов не найдено, происходит их добавление.
            {
                creatorSheets.CreateSheets(IdSreadssheet, result, servers, sheetService);
            }

            writerSheets.WriteSheet(IdSreadssheet, servers, sheetService);
        }
    }
}
