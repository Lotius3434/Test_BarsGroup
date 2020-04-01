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
        //private NpgsqlConnection connection;
        //private NpgsqlCommand NpgsqlCommand;
        //private NpgsqlDataReader result;
        IParseConfiguration parseConfiguration;
        
        IDictionary<string, string> Configurations;
        IDictionary<string, NpgsqlDataReader> DictDataReaders = new Dictionary<string, NpgsqlDataReader>();
        public ConnectionDb(IParseConfiguration parseConfiguration)
        {
            if (parseConfiguration != null)
            {
                this.parseConfiguration = parseConfiguration;
                
            }
            
        }
        public IDictionary<string, NpgsqlDataReader> GetServers()
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
                            connection.Close();
                            
                        }

                    }
                    catch(Exception e)
                    {
                        Console.WriteLine();
                        //доделать
                    }
                    
                }
            }
            return DictDataReaders;
        }
    }
}
