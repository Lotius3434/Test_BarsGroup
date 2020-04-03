using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.WorkServersPostgreSql
{
    class ParseConfiguration : IParseConfiguration 
    {
        Dictionary<string, string> configlist = new Dictionary<string, string>();
        string SearchKey = null;

        public Dictionary<string, string> GetConfigServers_Npgsql()
        {
            try
            {
                SearchKey = ConfigurationManager.AppSettings["SearchKey"];
                if (SearchKey != null)
                {
                    Console.WriteLine("Поиск серверов по настройке файла конфигурации");

                    
                        for (int a = 0; a < ConfigurationManager.ConnectionStrings.Count; a++)
                        {
                            if (ConfigurationManager.ConnectionStrings[a].ProviderName == SearchKey)
                            {

                                configlist.Add(ConfigurationManager.ConnectionStrings[a].Name, ConfigurationManager.ConnectionStrings[a].ConnectionString);
                            }


                        }
                        if (configlist.Count == 0)
                        {
                            throw new Exception("Не найдено серверов по ключевому слову");
                        }
                }
                else
                {
                    throw new Exception("Не найдено ключевого слова, для поиска сервера");
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: {0}\nНажмите любую кнопку для закрытия программы", e.Message);
                Console.ReadKey();
                Environment.Exit(1);
            }
            return configlist;
        }

        
    }
}
