using Castle.Windsor;
using Npgsql;
using System;
using System.Collections.Generic;
using TestBars.WorkProvider;

namespace TestBars.WorkServersPostgreSql
{
    public class ConnectionDb : IConnectionDb
    {
       
        IParseConfiguration parseConfiguration;
        IWriterServers writerServers;
        IProvider provider;
        IList<IServerObj> ListServerObjs = new List<IServerObj>();
        IDictionary<string, string> Configurations;
      
        public ConnectionDb(IParseConfiguration parseConfiguration, IWriterServers writerServers, IProvider provider)
        {
            if (parseConfiguration != null)
            {
                this.parseConfiguration = parseConfiguration;
                this.writerServers = writerServers;
                this.provider = provider;
            }
            
        }
        public IList<IServerObj> GetServers()
        {
            Configurations = parseConfiguration.GetConfigServers_Npgsql();
            if (Configurations != null)
            {
                
                foreach (var _Configurations in Configurations)
                {
                    
                    try
                    {
                        provider.Createconnection(_Configurations.Value);
                        provider.OpenConnection();

                        using (NpgsqlDataReader npgsqlDataReader = provider.GetDataReader())
                        {
                            writerServers.CreateServerObj(_Configurations.Key);

                            while (npgsqlDataReader.Read())
                            {
                                string nameDb = npgsqlDataReader.GetString(0);
                                string sizeDb = Converter.CalculateBytetoGB(npgsqlDataReader.GetInt64(1));
                                string updateDateDb = DateTime.Now.ToString("dd.MM.yyyy");
                                writerServers.WriteServerObjs(nameDb, sizeDb, updateDateDb);
                            }

                            ListServerObjs.Add(writerServers.GetServerObj());

                            provider.CloseConnection();
                        }    
                    }
                    catch(Exception e)
                    {
                        string[] code = e.Message.Split(':');
                        string ExceptionMessage;
                        switch (code[0])
                        {
                            case "28P01":
                                ExceptionMessage = "Не правильный пароль или User Id, для подключения к серверу";
                                break;
                            
                            default:
                                ExceptionMessage = e.Message;
                                break;
                        }

                        Console.WriteLine("Ошибка: {0}\nНажмите любую кнопку для закрытия программы", e.Message);
                        Console.ReadKey();
                        Environment.Exit(1);
                        
                    }
                    
                }
            }
            return ListServerObjs;
        }
    }
}
