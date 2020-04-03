using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    public interface IConnectionDb
    {
        IList<IServerObj> GetServers();
    }
}
