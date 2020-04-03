using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.WorkServersPostgreSql
{
    public interface IWriterServers
    {
        IList<IServerObj> WriteServerObjs(IDictionary<string, NpgsqlDataReader> DictDataReaders);
    }
}
