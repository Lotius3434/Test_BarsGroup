using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestBars.WorkServersPostgreSql;
using TestBars.WorkSheetsGoogle;
using System.Threading;
using Google.Apis.Sheets.v4;
using Google.Apis.Drive.v3;

namespace TestBars
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(new TimerCallback(StartProgram), null, 1000, 30000);

            
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
            
            List<IList<IList<Object>>> ListInfo; //Главный спиcок, который хранит в себе все сервера и их данные.

            IContainerServers containerServers = new ContainerServers(); //Контейнер, который создает и хранит в себе список серверов.

            if (containerServers.CreateServers())
            {
                List<IServer> servers = containerServers.GetServers;

                for (int a = 0; a < servers.Count; a++)
                {
                    servers[a].OpenConnection(); // Открытие соединения с серверами.
                }


                ListInfo = new List<IList<IList<Object>>>();
                for (int a = 0; a < servers.Count; a++)
                {
                    
                    ListInfo.Add(servers[a].GetBasesandSizes());//Добавление данных из баз серверов.
                }



                for (int a = 0; a < servers.Count; a++)
                {
                    servers[a].CloseConnection(); // Закрытие соединения с серверами.
                }

                
            }
            else
            {
                Console.WriteLine("Конфигурации не найдены, заполните данные сервера\nДля выхода из программы, нажмите 'q'\n");
                return;
            }



            UserAuthentication userAuthentication = new UserAuthentication(); // Аутенфикация пользователя.
            Services services = new Services();  //Создание сервисов.
            Config_Scope_Appname.credential = userAuthentication.Authentication(); //Добавление списка полномочий в общий стат класс.

            SheetsService sheetsService = services.GetSheetsService(); //Получение сервиса для гугл таблиц. 
            DriveService driveService = services.GetDriveService(); //Получение сервиса для гугл диска. 

            SearchSpreadsheets searchSheets = new SearchSpreadsheets();
            
            ISpreasheet spreasheet = new Spreasheet(sheetsService); // Реализация интерфейса, который содержит в себе весь фунционал работы с таблицами и листами.





            List<string> ListServer = new List<string>();
            foreach (var lisinf in ListInfo)
            {
                foreach (var li in lisinf[0])
                {
                    ListServer.Add(li.ToString());
                    break;
                }
            }



            List<string> listIdSreadssheet = searchSheets.Search(driveService); //Поиск таблиц на гугл диске.
            if (listIdSreadssheet.Count != 0)
            {
                foreach (var _lisId in listIdSreadssheet) //Если таблицы найдены, происходит доп. проверка соответсвие листов.
                {

                    spreasheet.ScanSheets(_lisId, ListServer, ListInfo); //Скан листов, если листов серверов по названию не найдено, они добавляются.
                    spreasheet.WriteSheet(_lisId, ListInfo); //Обновление листов в таблице.
                    Console.WriteLine("--Таблица обновлена...");
                }
            }
            else // Если таблица не найдена, создаеться новая.
            {
                
                Console.WriteLine("Таблица не найдена\nНачинается создание таблицы...");
                
                string spreadsheet = spreasheet.CreateSpreasheet(ListServer); //Создание таблицы и листов.
                spreasheet.WriteSheet(spreadsheet, ListInfo); //Добавление данных в таблицы.
            }

            Console.WriteLine("--Ожидание повторного запуска, интервал: 30 сек...\nДля выхода из программы, нажмите 'q'\n");

        }
        
    }
}
