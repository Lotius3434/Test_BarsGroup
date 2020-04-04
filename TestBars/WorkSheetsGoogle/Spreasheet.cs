using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using TestBars.WorkServersPostgreSql;
namespace TestBars.WorkSheetsGoogle
{
    public class Spreasheet : ISpreasheet //Класс для работы с таблицами и листами.
    {
        
        SheetsService service;
        public SheetsService SetSheetsService
        {
            set
            {
                if (service == null)
                {
                    service = value;
                }
            }
        }

      
        public string CreateSpreasheet(IList<IServerObj> servers) // Метод создания таблицы.
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
            Spreadsheet newSheet = service.Spreadsheets.Create(myNewSheet).Execute();


            Console.WriteLine("--Таблица создана\nСсылка на таблицу: {0}", newSheet.SpreadsheetUrl);
            return  newSheet.SpreadsheetId.ToString();

        }

        public void WriteSheet(string spreadsheet, IList<IServerObj> servers) // Метод добавления данных в листы.
        {

            //string range = "'Server1'!A1:D";

            foreach (var _servers in servers)
            {
                string range = null;
                IList<IList<Object>> valueToWrite = new List<IList<Object>>();


                IList<Object> FirstLineNames = new List<Object>()
                {
                    "Сервер",
                    "База данных",
                    "Размер в ГБ",
                    "Дата обновления"
                };
                valueToWrite.Add(FirstLineNames);
                foreach (var _DataBases in _servers.DataBases)
                {
                    IList<Object> listdatabase = new List<Object>();
                    listdatabase.Add(_servers.NameServer);
                    listdatabase.Add(_DataBases.name);
                    listdatabase.Add(_DataBases.size);
                    listdatabase.Add(_DataBases.updateDate);

                    range = _servers.NameServer + "!A1:D";
                    valueToWrite.Add(listdatabase);

                }
                IList<IList<Object>> drivesInfo = Drives.GetDriveFreeSize();
                foreach (var drv in drivesInfo)
                {
                    valueToWrite.Add(drv);
                }


                var valueRange = new ValueRange() { Values = valueToWrite };

                var update = service.Spreadsheets.Values.Update(valueRange, spreadsheet, range);
                update.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                try
                {
                    update.Execute();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка: {0}\nНе удалось записать данные в таблицу\nНажмите любую кнопку для закрытия программы",e.Message);
                    Console.ReadKey();
                    Environment.Exit(1);
                }

            }
                
            
            
        }   



        public void CreateSheets(string SpreadsheetId, List<string> ListServer, IList<IServerObj> servers) //Метод для создания листов.
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

                var batchUpdateRequest = service.Spreadsheets.BatchUpdate(batchUpdateSpreadsheetRequest, SpreadsheetId);
                batchUpdateRequest.Execute();
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


            WriteSheet(SpreadsheetId, newServers);

        }
        public void ScanSheets(string ListId, IList<IServerObj> servers)// Метод который парсит листы в таблице.
        {
            Console.WriteLine("Сканирование листов в таблице");




            List<string> sheets = new List<string>();
            List<string> result = new List<string>();

            Spreadsheet gsSpreadsheet;
            gsSpreadsheet = service.Spreadsheets.Get(ListId).Execute();
            foreach (Sheet gsSheet in gsSpreadsheet.Sheets)
            {
                sheets.Add(gsSheet.Properties.Title);
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
                CreateSheets(ListId, result, servers);
            }

        }
    }
}
