using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    /// <summary>
    /// Объект, который хранит в себе данные сервера и список DB.
    /// </summary>
    /// <inheritdoc/>
    public class ServerObj : IServerObj
    {
        private string _NameServer;
        private IList<IDbObj> dbObjs;
        /// <value>Содержит название сервера.</value>
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
        /// <value>Содержит список Db.</value>
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
