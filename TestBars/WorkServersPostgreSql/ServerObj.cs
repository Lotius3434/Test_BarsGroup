using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    public class ServerObj : IServerObj
    {
        private string _NameServer;
        private IList<IDbObj> dbObjs;
        
        public string NameServer
        {
            get
            {
                return _NameServer;
            }
            set
            {
                if (_NameServer == null)
                    _NameServer = value;
               
            }
        }
       public IList<IDbObj> DataBases
        {
            get
            {
                return dbObjs;
            }
            set
            {
                if (dbObjs == null)
                {
                    dbObjs = value;
                }
                
            }
        }


    }
}
