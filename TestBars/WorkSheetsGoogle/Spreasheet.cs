using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.WorkSheetsGoogle
{
    class Spreasheet : AbstractSpreadsheet //Класс для работы с таблицами и листами.
    {
        
        SheetsService service;

        public Spreasheet(SheetsService service)
        {
            this.service = service;
        }
        public override string CreateSpreasheet(List<string> ServersName) // Метод создания таблицы.
        {
            string spreadsheetName = Config_Scope_Appname.NameSpreadSheet;

            var myNewSheet = new Spreadsheet();
            myNewSheet.Properties = new SpreadsheetProperties();
            myNewSheet.Properties.Title = spreadsheetName;

            myNewSheet.Sheets = new List<Sheet>();
            for (int a = 0; a < ServersName.Count; a++)
            {
                var sheet = new Sheet();
                sheet.Properties = new SheetProperties();
                sheet.Properties.Title = ServersName[a];
                myNewSheet.Sheets.Add(sheet);
            }
            Spreadsheet newSheet = service.Spreadsheets.Create(myNewSheet).Execute();


            Console.WriteLine("--Таблица создана\nСсылка на таблицу: {0}", newSheet.SpreadsheetUrl);
            return  newSheet.SpreadsheetId.ToString();

        }

        public override void WriteSheet(string spreadsheet, List<IList<IList<Object>>> ListInfo) // Метод добавления данных в листы.
        {
            for (int a = 0; a < ListInfo.Count; a++)
            {
                //string range = "'Server1'!A1:D";


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

                foreach (var _ListInfo in ListInfo[a])
                {

                    valueToWrite.Add(_ListInfo);
                    range = _ListInfo[0].ToString() + "!A1:D";

                }

                IList<IList<Object>> drivesInfo = Drives.GetDriveFreeSize();
                foreach (var drv in drivesInfo)
                {
                    valueToWrite.Add(drv);
                }


                var valueRange = new ValueRange() { Values = valueToWrite };

                var update = service.Spreadsheets.Values.Update(valueRange, spreadsheet, range);
                update.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                
                update.Execute();
            }
            
        }   



        public override void CreateSheets(string SpreadsheetId, List<string> ListServer, List<IList<IList<Object>>> ListInfo) //Метод для создания листов.
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

            List<IList<IList<Object>>> newListInfo = new List<IList<IList<object>>>();

            for (int a = 0; a < ListServer.Count; a++)
            {
                foreach (var _ListInfo in ListInfo)
                {
                    foreach (var _ListInfo2 in _ListInfo)
                    {
                        if (ListServer[a].ToString() == _ListInfo2[0].ToString())
                        {
                            newListInfo.Add(_ListInfo);
                        }
                        break;
                    }

                }
            }


            WriteSheet(SpreadsheetId, newListInfo);

        }
        public override void ScanSheets(string ListId, List<string> ListServer, List<IList<IList<Object>>> ListInfo)// Метод который парсит листы в таблице.
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

            foreach (var nameServ in ListServer)
            {
                string Servsname = sheets.Find((x) => x == nameServ);
                if (Servsname == null)
                {
                    result.Add(nameServ);
                }
            }


            if (result.Count > 0) // Если соответствующих листов не найдено, происходит их добавление.
            {

                CreateSheets(ListId, result, ListInfo);
            }

        }
    }
}
