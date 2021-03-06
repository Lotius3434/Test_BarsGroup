﻿using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle
{
    /// <summary>
    /// Класс, который отвечает за запись данных в google лист.
    /// </summary>
    /// <inheritdoc/>
    class WriterSheets : IWriterSheets
    {
        IWorkFiles workFiles;
        IDrives drives;
        /// <summary>
        /// Конструктор через который просходят иньекции объектов.
        /// </summary>
        /// <param name="workFiles">Отвечает за запись данных в txt файл, если не удалось соединиться с google Api и сработало исключение.</param>
        /// <param name="drives">Отвечает за получения списка названий жестких дисков и количесво свободного места на них.</param>
        public WriterSheets(IWorkFiles workFiles, IDrives drives)
        {
            this.workFiles = workFiles;
            this.drives = drives;
        }
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
                IList<IList<Object>> drivesInfo = drives.GetDriveFreeSize();
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
                    Console.WriteLine("Ошибка: {0}\nНе удалось записать данные в таблицу.\nНажмите любую кнопку для закрытия программы.", e.Message);
                    workFiles.WriteFileTxt(servers);
                    Console.WriteLine("Данные записаны в файл: {0}, в корневой папке программы\nНажмите любую кнопку для закрытия программы", ConfigurationManager.AppSettings["PathFileTxt"]);
                    Console.ReadKey();
                    Environment.Exit(1);
                }

            }



        }
    }
}
