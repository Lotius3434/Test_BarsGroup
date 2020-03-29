using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.Update
{
    class ServerObj
    {
        private readonly string _NameServer;
        private readonly string _ConnectionParams;
        IList<IDbObj> dbObjs;
        public ServerObj(string _NameServer, string _ConnectionParams, IList<IDbObj> dbObjs)
        {
            if (_NameServer != null && _ConnectionParams != null)
            {
                this._NameServer = _NameServer;
                this._ConnectionParams = _ConnectionParams;
                this.dbObjs = dbObjs;
            }
        }
        public string NameServer
        {
            get
            {
                return _NameServer;
            }
        }
        public string ConnectionParams
        {
            get
            {
                return _ConnectionParams;
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
