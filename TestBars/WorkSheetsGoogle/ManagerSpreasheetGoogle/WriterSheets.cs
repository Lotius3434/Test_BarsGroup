using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle
{
    class WriterSheets : IWriterSheets
    {
        public void WriteSheet(string spreadsheet, IList<IServerObj> servers, SheetsService sheetService) // Метод добавления данных в листы.
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

                var update = sheetService.Spreadsheets.Values.Update(valueRange, spreadsheet, range);
                update.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                try
                {
                    update.Execute();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка: {0}\nНе удалось записать данные в таблицу\nНажмите любую кнопку для закрытия программы", e.Message);
                    Console.ReadKey();
                    Environment.Exit(1);
                }

            }



        }
    }
}
