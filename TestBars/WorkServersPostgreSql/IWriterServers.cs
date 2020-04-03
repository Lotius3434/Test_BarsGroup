using Npgsql;
using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    public interface IWriterServers
    {
        IList<IServerObj> WriteServerObjs(IDictionary<string, NpgsqlDataReader> DictDataReaders);
    }
}
