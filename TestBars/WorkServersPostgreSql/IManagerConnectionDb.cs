using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    public interface IManagerConnectionDb
    {
        IList<IServerObj> GetServers();
    }
}
