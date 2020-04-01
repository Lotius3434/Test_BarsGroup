using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.UpdateWorkServersPostgreSql
{
    interface IWriterServers
    {
        IList<IServerObj> WriteServerObjs(IDictionary<string, NpgsqlDataReader> DictDataReaders);
    }
}
