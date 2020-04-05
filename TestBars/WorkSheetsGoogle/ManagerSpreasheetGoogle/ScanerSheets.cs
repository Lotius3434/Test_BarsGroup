using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle
{
    class ScanerSheets : IScanerSheets
    {
        ICreatorSheets creatorSheets;
        IWriterSheets writerSheets;
        IWorkFiles workFiles;
        public ScanerSheets(ICreatorSheets creatorSheets, IWriterSheets writerSheets,IWorkFiles workFiles)
        {
            this.creatorSheets = creatorSheets;
            this.writerSheets = writerSheets;
            this.workFiles = workFiles;
        }
        public void ScanSheets(string IdSreadssheet, IList<IServerObj> servers, SheetsService sheetService)// Метод который парсит листы в таблице.
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
