using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.UpdateWorkServersPostgreSql
{
    class ServerObj : IServerObj
    {
        private readonly string _NameServer;
        IList<IDbObj> dbObjs;
        public ServerObj(string _NameServer, IList<IDbObj> dbObjs)
        {
            if (_NameServer != null)
            {
                this._NameServer = _NameServer;
                this.dbObjs = dbObjs;
            }
            else
            {
                
                return;
            }
        }
        public string NameServer
        {
            get
            {
                return _NameServer;
            }
        }
       public IList<IDbObj> DataBases
        {
            get
            {
                return dbObjs;
            }
        }


    }
}
