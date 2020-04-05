using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBars.WorkServersPostgreSql;

namespace TestBars.UpdateWorkSheetsGoogle
{
    class ManagerSpreasheet : IManagerSpreasheet
    {
        ICreatorSpreasheet creatorSpreasheet;
        IScanerSheets scanerSheets;
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
        public ManagerSpreasheet(ICreatorSpreasheet creatorSpreasheet, IScanerSheets scanerSheets)
        {
            this.creatorSpreasheet = creatorSpreasheet;
            this.scanerSheets = scanerSheets;
        }
        public void StartWorkSpreasheet(string IdSreadssheet, IList<IServerObj> servers)
        {
            if (IdSreadssheet == null)
            {
                Console.WriteLine("Таблица не найдена\nНачинается создание таблицы...");

                creatorSpreasheet.CreateSpreasheet(servers, service); //Создание таблицы и листов.
                



            }
            else // Если таблица найдена, создаеться новая.
            {
                scanerSheets.ScanSheets(IdSreadssheet, servers, service); //Скан листов, если листов серверов по названию не найдено, они добавляются.
                
                Console.WriteLine("--Таблица обновлена...");

            }

            Console.WriteLine("--Ожидание повторного запуска, интервал: 30 сек...\nДля выхода из программы, нажмите 'q'\n");

        }
    }
}
