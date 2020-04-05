using Google.Apis.Drive.v3;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;
using TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle;

namespace TestBars.WorkSheetsGoogle
{
    class ManagerSpreasheet : IManagerSpreasheet
    {
        ISearchSpreadsheets searchSpreadsheets;
        ICreatorSpreasheet creatorSpreasheet;
        IScanerSheets scanerSheets;
        
        SheetsService sheetService;
        DriveService driveService;
        public ManagerSpreasheet(IServices services, ISearchSpreadsheets searchSpreadsheets, ICreatorSpreasheet creatorSpreasheet, IScanerSheets scanerSheets)
        {
            this.searchSpreadsheets = searchSpreadsheets;
            this.creatorSpreasheet = creatorSpreasheet;
            this.scanerSheets = scanerSheets;

            sheetService = services.GetSheetsService();
            driveService = services.GetDriveService();
        }
        public void StartWorkSpreasheet(IList<IServerObj> servers)
        {
            string IdSreadssheet = searchSpreadsheets.Search(servers, driveService);

            if (IdSreadssheet == null)
            {
                Console.WriteLine("Таблица не найдена\nНачинается создание таблицы...");

                creatorSpreasheet.CreateSpreasheet(servers, sheetService); //Создание таблицы и листов.
            }
            else // Если таблица найдена, создаеться новая.
            {
                scanerSheets.ScanSheets(IdSreadssheet, servers, sheetService); //Скан листов, если листов серверов по названию не найдено, они добавляются.
                
                Console.WriteLine("--Таблица обновлена...");
            }

            Console.WriteLine("--Ожидание повторного запуска, интервал: 30 сек...\nДля выхода из программы, нажмите 'q'\n");

        }
    }
}
