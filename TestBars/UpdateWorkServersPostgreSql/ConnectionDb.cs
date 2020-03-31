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
        IWriterServers writerServers;
        Dictionary<string, string> Configurations;
        IList<IServerObj> servers;
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
                            NpgsqlDataReader result = NpgsqlCommand.ExecuteReader();
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
            return servers;
        }
    }
}
