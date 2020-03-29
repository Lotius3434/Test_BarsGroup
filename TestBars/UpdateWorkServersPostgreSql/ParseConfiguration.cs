using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.UpdateWorkServersPostgreSql
{
    class ParseConfiguration : IParseConfiguration 
    {
        Dictionary<string, string> configlist = new Dictionary<string, string>();
        string SearchKey = null;

        public Dictionary<string, string> GetConfigServers_Npgsql()
        {
            
            SearchKey = ConfigurationManager.AppSettings["SearchKey"];
            if (SearchKey != null )
            {
                Console.WriteLine("Поиск серверов по настройке файла конфигурации");

                if (ConfigurationManager.ConnectionStrings.Count != 0)
                {
                    for (int a = 0; a < ConfigurationManager.ConnectionStrings.Count; a++)
                    {
                        if (ConfigurationManager.ConnectionStrings[a].ProviderName == SearchKey)
                        {

                            configlist.Add(ConfigurationManager.ConnectionStrings[a].Name, ConfigurationManager.ConnectionStrings[a].ConnectionString);
                        }
                        

                    }
                    if (configlist.Count == 0)
                    {    
                        Console.WriteLine("Не найдено серверов");
                    }
                }
                else
                {
                    Console.WriteLine("Нет настроек серверов, в файле конфигурации");
                }
                
            }
            else
            {
                Console.WriteLine("Нет ключевого слова для поиска сервера");   
            }
            


            return configlist;
        }

        
    }
}
