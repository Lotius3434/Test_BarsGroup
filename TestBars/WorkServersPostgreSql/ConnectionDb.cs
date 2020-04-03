using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestBars.WorkServersPostgreSql
{
    public class ConnectionDb : IConnectionDb
    {
       
        IParseConfiguration parseConfiguration;
        IWriterServers writerServers;
        IList<IServerObj> ListServerObjs;
        IDictionary<string, string> Configurations;
        IDictionary<string, NpgsqlDataReader> DictDataReaders = new Dictionary<string, NpgsqlDataReader>();
        public ConnectionDb(IParseConfiguration parseConfiguration, IWriterServers writerServers)
        {
            if (parseConfiguration != null)
            {
                this.parseConfiguration = parseConfiguration;
                this.writerServers = writerServers;
            }
            
        }
        public IList<IServerObj> GetServers()
        {
            Configurations = parseConfiguration.GetConfigServers_Npgsql();
            if (Configurations != null)
            {
                
                foreach (var item in Configurations)
                {
                    
                    try
                    {
                        using (NpgsqlConnection connection = new NpgsqlConnection(item.Value))
                        {
                            NpgsqlCommand NpgsqlCommand = new NpgsqlCommand(SqlConfig.sqlquery,connection);
                            
                            connection.Open();

                            DictDataReaders.Add(item.Key, NpgsqlCommand.ExecuteReader());
                            ListServerObjs = writerServers.WriteServerObjs(DictDataReaders);

                            connection.Close();
                            
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
