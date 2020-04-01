using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestBars.UpdateWorkServersPostgreSql
{
    class ConnectionDb : IConnectionDb
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
                        Console.WriteLine("Ошибка: {0}",e.Message);                       
                    }
                    
                }
            }
            return ListServerObjs;
        }
    }
}
