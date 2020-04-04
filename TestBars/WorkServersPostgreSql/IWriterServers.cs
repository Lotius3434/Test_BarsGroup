using Npgsql;
using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    public interface IWriterServers
    {
        void CreateServerObj(string ServerName);
        void WriteServerObjs(string nameDb, string sizeDb, string updateDateDb);
        IServerObj GetServerObj();
    }
}
