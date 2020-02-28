using System;
using System.Collections.Generic;
using System.Configuration;

namespace TestBars.WorkServersPostgreSql
{
    class ParseConfiguration : IParseConfiguration //Класс, который реализует интерфейс парсинга всех данных из App.config.
    {
        public Dictionary<string, string> GetConfigServers_Npgsql()
        {
            Dictionary<string, string> configlist = new Dictionary<string, string>();

            Console.WriteLine("Поиск серверов по настройке файла конфигурации");

            for (int a = 0; a < ConfigurationManager.ConnectionStrings.Count; a++)
            {
                if (ConfigurationManager.ConnectionStrings[a].ProviderName == "Npgsql")
                {
                    
                    configlist.Add(ConfigurationManager.ConnectionStrings[a].Name, ConfigurationManager.ConnectionStrings[a].ConnectionString);
                }
                
            }
            
            
            return configlist;
        }
        
    }
}
