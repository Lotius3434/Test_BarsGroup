using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.UpdateWorkServersPostgreSql
{
    class WriterServers
    {
        IList<IServerObj> serverObjs = new List<IServerObj>();
        IList<NpgsqlDataReader> resultconnectionDb;
        public WriterServers(IConnectionDb connectionDb)
        {
            if (connectionDb != null)
            {
                resultconnectionDb = connectionDb.GetServers();
            }
        }

        public IList<IServerObj> WriteServer()
        {
            
            return serverObjs;
        }
    }
}
