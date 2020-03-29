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
        IList<IDbObj> dbObjs;
        public ServerObj(string _NameServer, IList<IDbObj> dbObjs)
        {
            if (_NameServer != null)
            {
                this._NameServer = _NameServer;
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
       public IList<IDbObj> DataBases
        {
            get
            {
                return dbObjs;
            }
        }


    }
}
