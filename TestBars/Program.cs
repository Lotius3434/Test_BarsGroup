using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestBars.WorkSheetsGoogle;
using System.Threading;
using Castle.Windsor;
using TestBars.WorkServersPostgreSql;
using TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle;

namespace TestBars
{
    class Program
    {
        static void Main(string[] args)
        {


            Timer timer = new Timer(new TimerCallback(StartProgram), null, 1000, 30000);


            //ConsoleKeyInfo button_press;
            //do
            //{
            //    Task.Delay(1000).Wait();
            //    button_press = Console.ReadKey();

            //} while (button_press.KeyChar != 'q');
            //timer.Dispose();
            //Console.WriteLine("\nВыход из программы");
            object state = 1;
            StartProgram(state);

        }
        static public void StartProgram(object state)
        {
            var container = new WindsorContainer();
            container.Install(new ConfigurationCastleWindsor());
            var connection = container.Resolve<IManagerConnectionDb>();

            IList<IServerObj> servers = connection.GetServers();

            
            IManagerSpreasheet managerSpreasheet = container.Resolve<IManagerSpreasheet>();
            managerSpreasheet.StartWorkSpreasheet(servers);
        }
        
    }
}
