using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    interface IContainerServers
    {
        List<IServer> GetServers
        {
            get;
        }
        void AddServers(IServer server);
        bool CreateServers();

    }
}
