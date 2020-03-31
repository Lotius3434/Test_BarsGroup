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
        

        public IList<IServerObj> WriteServer(NpgsqlDataReader result)
        {
            while (result.Read())
            {
                // Закончил здесьservers
            }
            return serverObjs;
        }
    }
}
