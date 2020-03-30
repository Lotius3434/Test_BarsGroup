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
        IList<IServerObj> servers;
        public ConnectionDb(IParseConfiguration parseConfiguration, IList<IServerObj> servers)
        {
            if (parseConfiguration != null)
            {
                this.parseConfiguration = parseConfiguration;
                this.servers = servers;
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

                            while ()
                            {

                            }
                        }

                    }
                    catch(Exception e)
                    {
                        Console.WriteLine();
                    }
                    //Закончил здесь
                }
            }
            return servers;
        }
    }
}
