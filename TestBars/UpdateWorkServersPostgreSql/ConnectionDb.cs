using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestBars.UpdateWorkServersPostgreSql
{
    class ConnectionDb
    {
        //private NpgsqlConnection connection;
        //private NpgsqlCommand NpgsqlCommand;
        //private NpgsqlDataReader result;
        IParseConfiguration parseConfiguration;
        
        Dictionary<string, string> Configurations;
        IList<NpgsqlDataReader> DataReader = new List<NpgsqlDataReader>();
        public ConnectionDb(IParseConfiguration parseConfiguration)
        {
            if (parseConfiguration != null)
            {
                this.parseConfiguration = parseConfiguration;
                
            }
            
        }
        public IList<NpgsqlDataReader> GetServers()
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
                            DataReader.Add(NpgsqlCommand.ExecuteReader());
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
            return DataReader;
        }
    }
}
