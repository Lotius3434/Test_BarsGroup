using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TestBars.WorkSheetsGoogle;
using System.Threading;
using Google.Apis.Sheets.v4;
using Google.Apis.Drive.v3;
using Castle.Windsor;
using TestBars.UpdateWorkServersPostgreSql;

namespace TestBars
{
    class Program
    {
        static public void Test(object state)
        {
            var container = new WindsorContainer();
            container.Install(new ConfigurationCastleWindsor());
            var connection = container.Resolve<IConnectionDb>();
            IList<IServerObj> servers = connection.GetServers();
            foreach (var item in servers)
            {
                foreach (var db in item.DataBases)
                {
                    Console.WriteLine("Имя сервера: {0}\n Название базы:{1} Размер: {2} Дата: {3}\n ---------"
                        ,item.NameServer
                        ,db.name
                        ,db.size
                        ,db.updateDate);
                }
                
            }
            
        }

        static void Main(string[] args)
        {
            
           
            Timer timer = new Timer(new TimerCallback(StartProgram), null, 1000, 10000);


            ConsoleKeyInfo button_press;
            do
            {
                Task.Delay(1000).Wait();
                button_press = Console.ReadKey();

            } while (button_press.KeyChar != 'q');
            timer.Dispose();
            Console.WriteLine("\nВыход из программы");

        }
        static public void StartProgram(object state)
        {
            var container = new WindsorContainer();
            container.Install(new ConfigurationCastleWindsor());
            
            var connection = container.Resolve<IConnectionDb>();
            IList<IServerObj> servers = connection.GetServers();

            IServices services = container.Resolve<IServices>();
            ISpreasheet spreasheet = container.Resolve<ISpreasheet>();
            ISearchSpreadsheets searchSpreadsheets = container.Resolve<ISearchSpreadsheets>();

            spreasheet.sheetsService = services.GetSheetsService();
            searchSpreadsheets.driveService = services.GetDriveService();
            


            string listIdSreadssheet = searchSpreadsheets.Search(); //Поиск таблиц на гугл диске.
            if (listIdSreadssheet != null)
            {
                

                    spreasheet.ScanSheets(listIdSreadssheet, servers); //Скан листов, если листов серверов по названию не найдено, они добавляются.
                    spreasheet.WriteSheet(listIdSreadssheet, servers); //Обновление листов в таблице.
                    Console.WriteLine("--Таблица обновлена...");
                
            }
            else // Если таблица не найдена, создаеться новая.
            {
                
                Console.WriteLine("Таблица не найдена\nНачинается создание таблицы...");
                
                string spreadsheet = spreasheet.CreateSpreasheet(servers); //Создание таблицы и листов.
                spreasheet.WriteSheet(spreadsheet, servers); //Добавление данных в таблицы.
            }

            Console.WriteLine("--Ожидание повторного запуска, интервал: 30 сек...\nДля выхода из программы, нажмите 'q'\n");

        }
        
    }
}
