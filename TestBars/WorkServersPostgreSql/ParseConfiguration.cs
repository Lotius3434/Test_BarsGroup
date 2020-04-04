using System;
using System.Collections.Generic;
using System.Configuration;

namespace TestBars.WorkServersPostgreSql
{
    public class ParseConfiguration : IParseConfiguration 
    {
        Dictionary<string, string> configlist = new Dictionary<string, string>();
        string SearchKey = ConfigurationManager.AppSettings["SearchKey"];
        ConnectionStringSettingsCollection ConnectionStrings = ConfigurationManager.ConnectionStrings;
        public Dictionary<string, string> GetConfigServers_Npgsql()
        {
            try
            {
                
                if (SearchKey != null)
                {
                    Console.WriteLine("Поиск серверов по настройке файла конфигурации");

                    
                        for (int a = 0; a < ConnectionStrings.Count; a++)
                        {
                            if (ConnectionStrings[a].ProviderName == SearchKey)
                            {

                                configlist.Add(ConnectionStrings[a].Name, ConnectionStrings[a].ConnectionString);
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
