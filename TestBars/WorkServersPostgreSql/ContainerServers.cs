using System;
using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    class ContainerServers : IContainerServers
    {
        private List<IServer> servers = new List<IServer>();

        Dictionary<string, string> keyValuePairs;
        public List<IServer> GetServers
        {
            get { return servers; }
        }
        public void AddServers(IServer server)
        {
            if (server != null)
            {
                servers.Add(server);
            }
        }
        public bool CreateServers()
        {
            IParseConfiguration _parseConfiguration = new ParseConfiguration();
            keyValuePairs = _parseConfiguration.GetConfigServers_Npgsql();

            if (keyValuePairs.Count > 0)
            {
                foreach (var lisDic in keyValuePairs)
                {
                    this.servers.Add(new Server(lisDic.Key, lisDic.Value));

                    Console.WriteLine("Найден сервер: {0}", lisDic.Key);
                }

                return true;
            }

            else
            {
                return false;
            }
            
        }
    }
}
