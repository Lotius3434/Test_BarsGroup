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
        private NpgsqlConnection connection;
        private NpgsqlCommand NpgsqlCommand;
        private NpgsqlDataReader result;
        IParseConfiguration parseConfiguration;
        Dictionary<string, string> Configurations;
        IList<IServerObj> servers;
        public ConnectionDb(IParseConfiguration parseConfiguration)
        {
            if (parseConfiguration != null)
            {
                this.parseConfiguration = parseConfiguration;
            }
            
        }
        public IList<IServerObj> GetServers()
        {
            Configurations = parseConfiguration.GetConfigServers_Npgsql();
            if (Configurations != null)
            {
                servers = new List<IServerObj>();
                foreach (var item in Configurations)
                {
                    //Закончил здесь
                }
            }
            return servers;
        }
    }
}
